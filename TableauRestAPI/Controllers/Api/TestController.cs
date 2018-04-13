using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TableauRestAPI.Models;
using TableauRestAPI.Services;

namespace TableauRestAPI.Controllers.Api
{
    public class TestController : ApiController
    {



        // Server Info
        public async Task<IHttpActionResult> getTest()
        {

            string path = "2.8/serverinfo";

            HttpResponseMessage response = await TableauHttpClient.client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {

                /// to use object : 
                ServerInfoAPIObject TheObj = await response.Content.ReadAsAsync<ServerInfoAPIObject>();
                return Ok(TheObj);


                // to use string 
                /*
                var result2 = await response.Content.ReadAsStringAsync();
                var details = JObject.Parse(result2);              
                return Ok(details);
                */

            }

            return BadRequest();

        }


        [HttpPost]
        [Route("api/TableauSignIn")]
        public async Task<IHttpActionResult> SignIn(postObject theobj)
        {
            string path = "2.8/auth/signin";
            var response = await TableauHttpClient.client.PostAsJsonAsync(path, theobj);

            if (response.IsSuccessStatusCode)
            {
                /// to use object : 
                postObject TheObj = await response.Content.ReadAsAsync<postObject>();

                //    SwapCurrentHeaderValue("X-Tableau-Auth", TheObj.credentials.token.ToString());
                //   TableauHTTPClient.addHeaderToken(TheObj.credentials.token);

                return Ok(TheObj);

                // to use string 
                /*
                var result2 = await response.Content.ReadAsStringAsync();
                var details = JObject.Parse(result2);              
                return Ok(details);
                */
            }

            return BadRequest();

        }




        private HttpRequestMessage Postrequest(string token1, string path)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, TableauHttpClient.client.BaseAddress.ToString() + path);

            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("X-Tableau-Auth", token1);

            requestMessage.Headers.Add("X-Tableau-Auth", token1);

            return requestMessage;

        }








        [HttpPost]
        [Route("api/TableauSignOut")]
        public async Task<IHttpActionResult> SignOut() {

            string path = "2.8/auth/signout"; 

            try
            {
                var token = Request.Headers.FirstOrDefault(c => c.Key == "X-Tableau-Auth").Value.FirstOrDefault();

                var Response = await TableauHttpClient.client.SendAsync(Postrequest(token,path));

                if (Response.IsSuccessStatusCode)
                {

                    return StatusCode(HttpStatusCode.NoContent);
                }

                var ResponseContent = await Response.Content.ReadAsStringAsync();

                var JsonResult = JObject.Parse(ResponseContent);

                return Ok(JsonResult);
            }
            catch (ArgumentNullException e) {

                return BadRequest("X-Tableau-Auth is missed !");

            }

        }


        [HttpGet]
        [Route("api/TableauToken")]
        public async Task<IHttpActionResult> GetToken()
        {


            var re = Request;
            var headers = re.Headers;

            return Ok(headers);

            ///
            if (headers.Contains("Custom"))
            {
                string token = headers.GetValues("Custom").First();
            }


            var headerValues = TableauHttpClient.client.DefaultRequestHeaders;
           // var id = headerValues.FirstOrDefault();


            return Ok(headerValues.ToString());



            foreach (var value in TableauHttpClient.client.DefaultRequestHeaders)
            {
                if (value.Key == "X-Tableau-Auth")
                    return Ok(value.Value);
            }


            var tokens = TableauHttpClient.client.DefaultRequestHeaders.FirstOrDefault(c => c.Key == "X-Tableau-Auth");

            //var token = tokens.Value.FirstOrDefault();
            return Ok(tokens.Value);



            return Ok("Token Does not exist");
        }





    }
}

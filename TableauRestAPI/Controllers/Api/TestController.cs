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


        void SwapCurrentHeaderValue( string HeaderVariable , string headerValue ) {

            TableauHttpClient.client.DefaultRequestHeaders.Remove(HeaderVariable);
            TableauHttpClient.client.DefaultRequestHeaders.Add(HeaderVariable, headerValue);

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

                SwapCurrentHeaderValue("X-Tableau-Auth", TheObj.credentials.token.ToString());

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
        [Route("api/TableauSignOut")]
        public async Task<IHttpActionResult> SignOut() {


            string path = "2.8/auth/signout";
            var response = await TableauHttpClient.client.PostAsJsonAsync(path,"");

            if (response.IsSuccessStatusCode)
            {
                TableauHttpClient.client.DefaultRequestHeaders.Remove("X-Tableau-Auth");

                return StatusCode(HttpStatusCode.NoContent);
            }
            return Unauthorized();
        }


        }
}

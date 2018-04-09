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

            HttpResponseMessage response = await MyHttpClient.client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {

                /// to use object : 
                ObjectToreturn TheObj = await response.Content.ReadAsAsync<ObjectToreturn>();
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
        [Route("api/SignIn")]
        public async Task<IHttpActionResult> SignIn(postObject theobj)
        {

            string path = "2.8/auth/signin";

            var response = await MyHttpClient.client.PostAsJsonAsync(path, theobj);

            if (response.IsSuccessStatusCode)
            {


                /// to use object : 
                postObject TheObj = await response.Content.ReadAsAsync<postObject>();
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










        }
}

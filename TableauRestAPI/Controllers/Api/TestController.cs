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
using TableauRestAPI.Services;

namespace TableauRestAPI.Controllers.Api
{
    public class TestController : ApiController
    {


        class ObjectToreturn
        {
          public  serverInfo serverInfo { get; set; }
          public string restApiVersion { get; set; }
        }




        public class productVersion {
            public string value { get; set; }
            public string build { get; set; }
        }


        public class serverInfo {
            public productVersion productVersion { get; set; }
          
        }



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










    }
}

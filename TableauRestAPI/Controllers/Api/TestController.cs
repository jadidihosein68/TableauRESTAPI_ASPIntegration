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


       public class CredentialTableau
        {
            public string name { get; set; }
            public string password { get; set; }
            public site site { get; set; }



            public CredentialTableau(string name,  string password, site site)
            {

                this.name = name;
                this.password = password;
                this.site = site;

            }
        }



      public class postObject
        {
            public  CredentialTableau credentials { get; set; }
            public postObject(CredentialTableau CredentialTableau)
            {
                credentials = CredentialTableau;
            }

        }

        public class site
        {
            public site(string contentUrl)
            {
                this.contentUrl = contentUrl;
            }
            public string contentUrl { get; set; }
        }


        [HttpPost]
        [Route("api/SignIn")]
        public async Task<IHttpActionResult> SignIn(postObject theobj)
        {

            string path = "2.8/auth/signin";



            // HttpResponseMessage response = await MyHttpClient.client.PostAsJsonAsync<string>(path);

            /*
            var values = new Dictionary<string, string>()
                    {
                        {"username", SecurityHelper.EncryptQueryString(username)},
                        {"password", SecurityHelper.EncryptQueryString(password)},
                    };
            var content = new FormUrlEncodedContent(values);
            */

            //  var response = await MyHttpClient.client.PostAsync(path, content);


         //   postObject theobj = new postObject(new CredentialTableau("tabadmin", "tabadmin", new site("")));


            var response = await MyHttpClient.client.PostAsJsonAsync(path, theobj);

            if (response.IsSuccessStatusCode)
            {
                /*
                /// to use object : 
                ObjectToreturn TheObj = await response.Content.ReadAsAsync<ObjectToreturn>();
                return Ok(TheObj);
                */

                // to use string 
                
                var result2 = await response.Content.ReadAsStringAsync();
                var details = JObject.Parse(result2);              
                return Ok(details);
                

            }

            return BadRequest();

        }










        }
}

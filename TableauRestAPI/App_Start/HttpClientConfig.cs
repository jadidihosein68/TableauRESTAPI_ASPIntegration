using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace TableauRestAPI.App_Start
{
    public class HttpClientConfig
    {

        public static void RegisterClient(HttpClient client) {

            client.BaseAddress = new Uri("http://tableau:8000/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        }



    }
}
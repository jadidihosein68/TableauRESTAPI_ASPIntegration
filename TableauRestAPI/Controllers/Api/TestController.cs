using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TableauRestAPI.Controllers.Api
{
    public class TestController : ApiController
    {



        public IHttpActionResult getTest() {

            return Ok("I am fucking working! ");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TableauRestAPI.Controllers
{
    public class TableauController : Controller
    {
        // GET: Tableau
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Login() // for tesint purpose 
        {
            return View();
        }



    }
}
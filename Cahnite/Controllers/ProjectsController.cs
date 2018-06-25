using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cahnite.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Welcome(string name, int ID = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = ID;

            return View();
        }
    }
}
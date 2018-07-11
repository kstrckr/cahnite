using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Cahnite.Models;

namespace Cahnite.Controllers
{
    public class ProjectsController : Controller
    {
        
        // GET: Projects
            public ActionResult Index()
            {
                using (ProjectDBContext db = new ProjectDBContext())
                {
                    return View(db.Projects.ToList());
                }
                
            }

        public ActionResult ProjectDetail(int? id)
        {
            using (ProjectDBContext db = new ProjectDBContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Project project = db.Projects.Find(id);

                if (project == null)
                {
                    return HttpNotFound();
                }

                return View(project);
            }
 
        }

        public ActionResult ProjectEdit(int? id)
        {
            using (ProjectDBContext db = new ProjectDBContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Project project = db.Projects.Find(id);

                if (project == null)
                {
                    return HttpNotFound();
                }

                return View(project);
            }
        }

    }
}
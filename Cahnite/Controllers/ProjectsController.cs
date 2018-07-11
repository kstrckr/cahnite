using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using Cahnite.Models;

namespace Cahnite.Controllers
{
    public class ProjectsController : Controller
    {
        
        // GET: Projects
            public ActionResult Index()
            {
                using (CahniteContext db = new CahniteContext())
                {
                    ProjectListViewModel projectList = new ProjectListViewModel
                    {
                        Projects = db.Projects.Select(p => new ProjectViewModel
                        {
                            ID = p.ID,
                            Title = p.Title,
                            Intro = p.Intro,
                            ImageUrl = p.ImageUrl
                        }).ToList()
                    };
                    return View(projectList);
                }
                
            }

        public ActionResult ProjectDetail(int? id)
        {
            using (CahniteContext db = new CahniteContext())
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
            using (CahniteContext db = new CahniteContext())
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectEdit([Bind(Include ="ID, Title, Intro, BodyHtml, ImageUrl, Favorite")] Project project)
        {
            using (CahniteContext db = new CahniteContext())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(project).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(project);
            }

        }
    }
}
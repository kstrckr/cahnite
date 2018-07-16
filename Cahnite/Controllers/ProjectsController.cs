using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using Cahnite.Models;

namespace Cahnite.Controllers
{
    public class ProjectsController : Controller
    {
        
     // GET: Project List/INDEX
            public ActionResult Index()
            {
                using (CahniteContext db = new CahniteContext())
                {
                    // Creats the ListView of ProjectView models
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

    //  GET: Project Detail
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

    // GET: Project Create
        public ActionResult ProjectCreate()
        {
            return View("ProjectEdit", new Project());
        }

    // GET: Project Edit
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

        // POST: Project Edit Post
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ProjectEdit([Bind(Include ="ID, Title, Intro, BodyHtml, ImageUrl, Favorite")] Project project)
        //{
        //    using (CahniteContext db = new CahniteContext())
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(project).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(project);
        //    }

        //}

    // POST: Project Edit Post - alternate version
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectEdit(ProjectViewModel projectViewModel)
        {
            using (CahniteContext db = new CahniteContext())
            {
                Project project = db.Projects.Single(p => p.ID == projectViewModel.ID);

                if (project != null)
                {
                    project.Title = projectViewModel.Title;
                    project.Intro = projectViewModel.Intro;
                    project.BodyHtml = projectViewModel.ImageUrl;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectDelete(ProjectViewModel projectViewModel)
        {
            using (CahniteContext db = new CahniteContext())
            {
                Project project = db.Projects.SingleOrDefault(p => p.ID == projectViewModel.ID);
                
                if (project != null)
                {
                    db.Projects.Remove(project);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }


                return new HttpNotFoundResult();
            }
            
        }
    }
}
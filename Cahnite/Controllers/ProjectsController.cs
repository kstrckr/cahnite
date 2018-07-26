
using System;
using System.Collections.Generic;
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
            //ProjectListViewModel projectList = new ProjectListViewModel
            //{
            //    Projects = db.Projects.Select(p => new ProjectViewModel
            //    {
            //        ID = p.ID,
            //        Title = p.Title,
            //        Intro = p.Intro,
            //        ImageUrl = p.ImageUrl
            //    }).ToList()

            //};

                IQueryable<Project> publishedProjectList = db.Projects.Where(p => p.Publish == true).OrderByDescending(p => p.CreatedOn);

                ProjectListViewModel projectList = new ProjectListViewModel
                {
                    Projects = publishedProjectList.Select(p => new ProjectViewModel
                    {
                        ID = p.ID,
                        Url = p.Url,
                        Title = p.Title,
                        Intro = p.Intro,
                        ImageUrl = p.ImageUrl
                    }).ToList()
                                        
                };

                projectList.TotalProjects = projectList.Projects.Count;

                return View(projectList);
            }
                
        }

        public ActionResult Unpublished()
        {
            using (CahniteContext db = new CahniteContext())
            {

                IQueryable<Project> publishedProjects = db.Projects.Where(p => p.Publish == false);

                ProjectListViewModel projectList = new ProjectListViewModel
                {
                    Projects = publishedProjects.Select(p => new ProjectViewModel
                    {
                        ID = p.ID,
                        Url = p.Url,
                        Title = p.Title,
                        Intro = p.Intro,
                        ImageUrl = p.ImageUrl
                    }).ToList()
                };

                projectList.TotalProjects = projectList.Projects.Count;

                return View(projectList);
            }
        }


    //  GET: Project Detail
        public ActionResult ProjectDetail(string project_url)
        {
            using (CahniteContext db = new CahniteContext())
            {
                if (project_url == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Project project = db.Projects
                    .Where(p => p.Url == project_url)
                    .SingleOrDefault();


                if (project != null)
                {
                    ProjectViewModel projectViewModel = new ProjectViewModel
                    {
                        ID = project.ID,
                        Url = project.Url,
                        Title = project.Title,
                        Intro = project.Intro,
                        ImageUrl = project.ImageUrl,
                        BodyHtml = project.BodyHtml,
                        Favorite = project.Favorite
                    };

                    return View(projectViewModel);                    
                }

                return HttpNotFound();
            }
 
        }

    // GET: Project Create
        public ActionResult ProjectCreate()
        {
            ProjectViewModel blankProject = new ProjectViewModel();

            blankProject.Title = "New Project";
            blankProject.ImageUrl = "http://via.placeholder.com/350x350";

            return View("ProjectCreateEdit", blankProject);
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

                if (project != null)
                {
                    ProjectViewModel projectViewModel = new ProjectViewModel
                    {
                        ID = project.ID,
                        Title = project.Title,
                        Intro = project.Intro,
                        ImageUrl = project.ImageUrl,
                        BodyHtml = project.BodyHtml,
                        Favorite = project.Favorite,
                        Publish = project.Publish,
                        CreatedOn = project.CreatedOn,
                        EditedOn = project.EditedOn

                    };

                    return View("ProjectCreateEdit", projectViewModel);
                                        
                }

                return HttpNotFound();
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

    // POST: Project Edit/Create - alternate version
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectCreateEdit(ProjectViewModel projectViewModel)
        {
            using (CahniteContext db = new CahniteContext())
            {
                Project project;

                if (projectViewModel.ID <= 0)
                {
                    project = new Project
                    {
                        CreatedOn = DateTime.Now,
                        EditedOn = DateTime.Now
                    };
                }
                else
                {
                    project = db.Projects.Single(p => p.ID == projectViewModel.ID);
                }
                

                if (project != null)
                {
                    project.Title = projectViewModel.Title;
                    
                    project.Intro = projectViewModel.Intro;
                    project.BodyHtml = projectViewModel.BodyHtml;
                    project.ImageUrl = projectViewModel.ImageUrl;
                    project.Favorite = projectViewModel.Favorite;
                    project.Publish = projectViewModel.Publish;
                    project.EditedOn = DateTime.Now;

                    if (projectViewModel.RePublish)
                    {
                        project.CreatedOn = DateTime.Now;
                    }

                    if (ModelState.IsValid)
                    {
                        project.Url = projectViewModel.Title.Replace(" ", "_");

                        if (project.ID != 0)
                        {

                            db.SaveChanges();
                        }
                        else
                        {
                            db.Projects.Add(project);
                            db.SaveChanges();
                        }


                        return RedirectToAction("Index");
                    }

                    projectViewModel.CreatedOn = project.CreatedOn;
                    projectViewModel.EditedOn = project.EditedOn;

                    return View(projectViewModel);
                        
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
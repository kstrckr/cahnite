
using System;

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
                // returns only published projects
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

    // GET: Project List/Unpublished
    // list of all created, but unpublished projects
        public ActionResult Unpublished()
        {
            using (CahniteContext db = new CahniteContext())
            {
                // returns only unpublished projects
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

                // returns the a single project based on the url parameter
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

            // defines the pre-filled values for the create view
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


    // POST: Project Edit/Create - alternate version
        // the post will either creat a new project if ID = 0, or update an existing project if ID exists
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectCreateEdit(ProjectViewModel projectViewModel)
        {
            using (CahniteContext db = new CahniteContext())
            {
                Project project;

                // makes a new project if creating
                if (projectViewModel.ID <= 0)
                {
                    project = new Project
                    {
                        CreatedOn = DateTime.Now,
                        EditedOn = DateTime.Now
                    };
                }
                // otherwise assign an existing project to var project
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
                        // auto-defines the url parameter used to access the detail view
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

                    // these need defining before returing the ViewModel, otherwise the wrong dates are shown 
                    // if there are validation errors and the ViewModel is returned to the edit view w/ warnings

                    projectViewModel.CreatedOn = project.CreatedOn;
                    projectViewModel.EditedOn = project.EditedOn;

                    return View(projectViewModel);
                        
                }
            }

            return new HttpNotFoundResult();
        }

        // DELETE via Post request
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
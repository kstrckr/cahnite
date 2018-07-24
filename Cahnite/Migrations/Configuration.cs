using System;
using System.Data.Entity.Migrations;

namespace Cahnite.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<CahniteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Cahnite.Models.ProjectDBContext";
        }

        protected override void Seed(CahniteContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            string placeholderImgLink = "http://via.placeholder.com/350x350";
                                                
            context.Projects.AddOrUpdate(p => p.Title,
                new Models.Project
                {
                    Title = "Iowa State Liquor Sales Data Project",
                    Intro = "A Python data project using Jupyter Notebook, Pandas, and Bokeh",
                    BodyHtml = "<h1>Parsing, creating a database for, and analyzing 13 Million sales records</h1>",
                    ImageUrl = placeholderImgLink,
                    Publish = true,
                    CreatedOn = DateTime.Now.Subtract(new TimeSpan(-7, 0, 0, 0)),
                    EditedOn = DateTime.Now.Subtract(new TimeSpan(-3, 0, 0, 0))
                },
                new Models.Project
                {
                    Title = "Commageddon",
                    Intro = "File name validation script for Saks Photo Studio",
                    BodyHtml = "<b>Python project parsing CSVs to generate expected file names</b>",
                    ImageUrl = placeholderImgLink,
                    Publish = true,
                    CreatedOn = DateTime.Now.Subtract(new TimeSpan(-6, 0, 0, 0)),
                    EditedOn = DateTime.Now.Subtract(new TimeSpan(-4, 0, 0, 0))
                },
                new Models.Project
                {
                    Title = "MEAN Match Master",
                    Intro = "A Matching Memory game with server side game logic and persistant high scores",
                    BodyHtml = "<b>A MEAN stack project</b>",
                    ImageUrl = placeholderImgLink,
                    Publish = true,
                    CreatedOn = DateTime.Now.Subtract(new TimeSpan(-5, 0, 0, 0)),
                    EditedOn = DateTime.Now.Subtract(new TimeSpan(-2, 0, 0, 0))
                },
                new Models.Project
                {
                    Title = "That DAM Bot",
                    Intro = "A Bulk download tool for the EvolPhin Digital Asset Management System",
                    BodyHtml = "<b>Managed and verified the downloading of 12 Terrabytes of photography assets.</b>",
                    ImageUrl = placeholderImgLink,
                    Publish = true,
                    CreatedOn = DateTime.Now.Subtract(new TimeSpan(-4, 0, 0, 0)),
                    EditedOn = DateTime.Now.Subtract(new TimeSpan(-1, 0, 0, 0))
                });

        }
    }
}

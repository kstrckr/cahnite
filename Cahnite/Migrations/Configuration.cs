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
                    Title = "Iowa Liquor Sales Data Project",
                    Url = "Iowa_State_Liquor_Sales_Data_Project",
                    Intro = "A Python data project using Jupyter Notebook, Pandas, and Bokeh",
                    BodyHtml = "<b>Parsing, creating a database for, and analyzing 13 Million sales records</b>",
                    ImageUrl = "https://www.kurtstrecker.com/project_imgs/py_data_sqr_350.png",
                    Publish = true,
                    CreatedOn = DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0)),
                    EditedOn = DateTime.Now.Subtract(new TimeSpan(3, 0, 0, 0))
                },
                new Models.Project
                {
                    Title = "Commageddon",
                    Url = "Commageddon",
                    Intro = "File name validation script for Saks Photo Studio",
                    BodyHtml = "<b>Python project parsing CSVs to generate expected file names</b>",
                    ImageUrl = "https://www.kurtstrecker.com/project_imgs/commageddon_sqr_350.jpg",
                    Publish = false,
                    CreatedOn = DateTime.Now.Subtract(new TimeSpan(6, 0, 0, 0)),
                    EditedOn = DateTime.Now.Subtract(new TimeSpan(4, 0, 0, 0))
                },
                new Models.Project
                {
                    Title = "MEAN Match Master",
                    Url = "MEAN_Match_Master",
                    Intro = "A Matching Memory game with server side game logic and persistant high scores",
                    BodyHtml = "<b>A MEAN stack project</b>",
                    ImageUrl = "https://www.kurtstrecker.com/project_imgs/mm_sqr_350.png",
                    Publish = true,
                    CreatedOn = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0)),
                    EditedOn = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0))
                },
                new Models.Project
                {
                    Title = "That DAM Bot",
                    Url = "That_DAM_Bot",
                    Intro = "A Bulk download tool for the EvolPhin Digital Asset Management System",
                    BodyHtml = "<b>Managed and verified the downloading of 12 Terrabytes of photography assets.</b>",
                    ImageUrl = "https://www.kurtstrecker.com/project_imgs/dam_bot_sqr_350.jpg",
                    Publish = true,
                    CreatedOn = DateTime.Now.Subtract(new TimeSpan(4, 0, 0, 0)),
                    EditedOn = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))
                });

        }
    }
}

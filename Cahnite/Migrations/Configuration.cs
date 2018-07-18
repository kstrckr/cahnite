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
                    Title = "Python Data Project",
                    Intro = "Python Data Project Intro",
                    BodyHtml = "<b>Python Data Project Body Text Here</b>",
                    ImageUrl = placeholderImgLink
                },
                new Models.Project
                {
                    Title = "Commageddon",
                    Intro = "File name validation script for Saks Photo Studio",
                    BodyHtml = "<b>Python project parsing CSVs to generate expected file names</b>",
                    ImageUrl = placeholderImgLink
                },
                new Models.Project
                {
                    Title = "MEAN Match Master",
                    Intro = "A Matching Memory game with server side game logic and persistant high scores",
                    BodyHtml = "<b>A MEAN stack project</b>",
                    ImageUrl = placeholderImgLink
                },
                new Models.Project
                {
                    Title = "That DAM Bot",
                    Intro = "A Bulk download tool for the EvolPhin Digital Asset Management System",
                    BodyHtml = "<b>Managed and verified the downloading of 12 Terrabytes of photography assets.</b>",
                    ImageUrl = placeholderImgLink
                });

        }
    }
}

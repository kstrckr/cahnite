namespace Cahnite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cahnite.Models.ProjectDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Cahnite.Models.ProjectDBContext";
        }

        protected override void Seed(Cahnite.Models.ProjectDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Projects.AddOrUpdate(p => p.ID,
                new Models.Project()
                {
                    ID = 1,
                    Title = "Python Data Project",
                    Intro = "Python Data Project Intro",
                    BodyHtml = "<h1>Python Data Project</h1><p>Body Text Here</p>",
                    ImageUrl = "http://via.placeholder.com/350x150"
                },
                new Models.Project()
                {
                    ID = 2,
                    Title = "Commageddon",
                    Intro = "File name validation script for Saks Photo Studio",
                    BodyHtml = "<p>Python project parsing CSVs to generate expected file names</p>",
                    ImageUrl = "http://via.placeholder.com/350x150"
                },
                new Models.Project()
                {
                    ID = 3,
                    Title = "MEAN Match Master",
                    Intro = "A Matching Memory game with server side game logic and persistant high scores",
                    BodyHtml = "<p>A MEAN stack project</p>",
                    ImageUrl = "http://via.placeholder.com/350x150"
                },
                new Models.Project()
                {
                    ID = 4,
                    Title = "That DAM Bot",
                    Intro = "A Bulk download tool for the EvolPhin Digital Asset Management System",
                    BodyHtml = "<p>Managed and verified the downloading of 12 Terrabytes of photography assets.</p>",
                    ImageUrl = "http://via.placeholder.com/350x150"
                });
        }
    }
}

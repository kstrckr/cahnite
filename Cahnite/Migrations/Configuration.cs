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
                    ImageUrl = "path-to-image"
                });
        }
    }
}

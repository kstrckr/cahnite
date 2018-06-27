using System;
using System.Data.Entity;

namespace Cahnite.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Intro { get; set; }
        public string BodyHtml { get; set; }
        public string ImageUrl { get; set; }
        public bool Favorite { get; set; }
    }

    public class ProjectDBContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
    }
}


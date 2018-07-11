using Cahnite.Models;
using System.Data.Entity;

namespace Cahnite
{
    public class CahniteContext : DbContext
    {
        public CahniteContext() : base("name=Cahnite") { }

        public virtual DbSet<Project> Projects { get; set; }

    }
}
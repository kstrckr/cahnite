using System.Data.Entity;



namespace Cahnite.Models
{
    public class ProjectViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Intro { get; set; }
        public string ImageUrl { get; set; }
        [System.Web.Mvc.AllowHtml]
        public string BodyHtml { get; set; }
        public bool Favorite { get; set; }
    }
}
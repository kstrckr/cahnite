using System;
using System.ComponentModel.DataAnnotations;

namespace Cahnite.Models
{
    public class Project
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Intro { get; set; }
        [Required]
        [System.Web.Mvc.AllowHtml]
        public string BodyHtml { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public bool Favorite { get; set; }
        [Required]
        public bool Publish { get; set; } 
        [Required]
        public DateTime CreatedOn { get; set; } 
        [Required]
        public DateTime EditedOn { get; set; }
    }

}


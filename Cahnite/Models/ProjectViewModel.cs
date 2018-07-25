using System;
using System.ComponentModel.DataAnnotations;

namespace Cahnite.Models
{
    public class ProjectViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Intro { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [System.Web.Mvc.AllowHtml]
        [DataType(DataType.MultilineText)]
        public string BodyHtml { get; set; }

        [Required]
        public bool Favorite { get; set; }

        [Required]
        [Display(Name = "Update CreatedOn")]
        public bool RePublish { get; set; }

        [Required]
        public bool Publish { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime EditedOn { get; set; }
    }
}
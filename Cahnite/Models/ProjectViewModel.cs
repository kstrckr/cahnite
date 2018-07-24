﻿using System.ComponentModel.DataAnnotations;

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
        public bool Republish { get; set; }
    }
}
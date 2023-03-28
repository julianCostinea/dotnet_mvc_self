using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace DTO
{
    public class PostDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a short content")]
        public string ShortContent { get; set; }

        [Required(ErrorMessage = "Please enter a seo link")]
        public string SeoLink { get; set; }
        
        public bool isUpdate { get; set; } = false;
        
        [Required(ErrorMessage = "Please enter a category")]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        [Display(Name = "Post Image")] 
        public HttpPostedFileBase PostImage { get; set; }
        public string ImagePath { get; set; }
    }
}
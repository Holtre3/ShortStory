using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShortStoryReviewSite.Models
{
    public class Review
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        public double Score { get; set; }
        [Required]
        [Display(Name = "Review Content")]
        public string ReviewText { get; set; }
        [Required]
        [Display(Name = "Review Date")]
        public DateTime ReviewDate { get; set; }
        
        public int StoryId { get; set; }

    }
}
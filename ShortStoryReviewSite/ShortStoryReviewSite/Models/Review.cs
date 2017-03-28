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
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int StoryId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public double Score { get; set; }
        [Required]
        public string ReviewText { get; set; }
        [Required]
        public DateTime ReviewDate { get; set; }

    }
}
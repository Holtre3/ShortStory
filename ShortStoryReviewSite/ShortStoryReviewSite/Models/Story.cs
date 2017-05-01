using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShortStoryReviewSite.Models
{
    public enum StoryGenre
    {
        Fiction,
        Comedy,
        Drama,
        Horror,
        Nonfiction,
        RealisticFiction,
        Romancenovel,
        Satire,
        Tragedy,
        Tragicomedy,
        Fantasy
    }
    public class Story
    { 
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is a Required Field.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Title Length Between 2 to 200 character.")]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name = "Story Content")]
        [StringLength(100000, MinimumLength = 10, ErrorMessage ="The body of your text must between 10 and 100000 characters long.")]
        [AllowHtml]
        public string StoryContent { get; set; }
        [Required(ErrorMessage ="Must Select Genre.")]
        public StoryGenre Genre { get; set; }
        public double Score { get; set; }
        [Display(Name = "Submission Date")]
        public DateTime SubmissionDate { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
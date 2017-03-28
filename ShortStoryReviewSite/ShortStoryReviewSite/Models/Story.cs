using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Company Name is Required Field.")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "Company Name Length Between 4 to 200 character")]
        public string Title { get; set; }
        [StringLength(200, MinimumLength = 4, ErrorMessage = "Address Length Between 4 to 200 character")]
        [Required]
        public string Author { get; set; }
        [Required]
        public string FilePath { get; set; }
        [Required]
        public StoryGenre Genre { get; set; }
        [Required]
        public double Score { get; set; }
        [Required]
        public DateTime SubmissionDate { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
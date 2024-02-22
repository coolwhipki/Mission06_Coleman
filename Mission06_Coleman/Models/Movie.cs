using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Coleman.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; } = null;
        [Required(ErrorMessage = "Title of film is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Year of film is required")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later")]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required(ErrorMessage = "Edited is required")]
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        [Required(ErrorMessage = "Copied To Plex is required")]
        public bool CopiedToPlex {  get; set; }
        [StringLength(25)]
        public string? Notes { get; set; }
    }
}


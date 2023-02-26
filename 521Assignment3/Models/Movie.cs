using System.ComponentModel.DataAnnotations;

namespace _521Assignment3.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string IMBDLink { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public byte[] Media { get; set; }


    }
}

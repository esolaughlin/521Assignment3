using System.ComponentModel.DataAnnotations;

namespace _521Assignment3.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
       
        public string? IMDBLink { get; set; }
        
        public byte[]? Photo { get; set; }

    }
}

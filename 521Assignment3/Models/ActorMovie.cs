using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _521Assignment3.Models
{
    public class ActorMovie
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        [ForeignKey("Actor")]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

    }
}

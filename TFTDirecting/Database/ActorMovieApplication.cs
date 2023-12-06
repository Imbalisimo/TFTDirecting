using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TFTDirecting.Database
{
    public class ActorMovieApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        public int ActorId { get; set; }
        [ForeignKey("ActorId")]
        public User Actor { get; set; }

        public bool IsAcceptedByActor { get; set; }
        public bool IsAcceptedByDirector { get; set; }
    }
}

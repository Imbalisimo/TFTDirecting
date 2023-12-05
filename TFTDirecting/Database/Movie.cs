using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TFTDirecting.Database
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Duration { get; set; }
        public double Budget { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }

        public int DirectorId { get; set; }
        [ForeignKey("DirectorId")]
        public User Director { get; set; }

        public ICollection<User> Actors { get; set; }
                    = new List<User>();

        public ICollection<Genre> Genres { get; set; }
                    = new List<Genre>();
    }
}

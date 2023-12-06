using TFTDirecting.Database;

namespace TFTDirecting.Commands
{
    public class UpdateGenreCommand
    {
        public string Name { get; set; }

        public Genre ToGenre(int genreId)
        {
            return new Genre
            {
                Id = genreId,
                Name = Name,
            };
        }
    }
}

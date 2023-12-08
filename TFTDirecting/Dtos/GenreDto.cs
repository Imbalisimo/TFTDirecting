using TFTDirecting.Database;

namespace TFTDirecting.Dtos
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GenreDto(Genre? genre)
        {
            if (genre == null) return;

            Id = genre.Id;
            Name = genre.Name;
        }

        public Genre ToGenre()
        {
            return new Genre
            {
                Id = Id,
                Name = Name
            };
        }
    }
}

using TFTDirecting.Commands;
using TFTDirecting.Database;
using TFTDirecting.Dtos;

namespace TFTDirecting.Contracts
{
    public interface IGenreRepository
    {
        GenreDto GetById(int genreId);
        void Create(CreateGenreCommand genre);
        void Update(int genreId, UpdateGenreCommand genre);
        void Delete(Genre genre);
    }
}

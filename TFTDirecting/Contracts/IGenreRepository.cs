using TFTDirecting.Commands;
using TFTDirecting.Database;

namespace TFTDirecting.Contracts
{
    public interface IGenreRepository
    {
        Genre GetById(int genreId);
        void Create(CreateGenreCommand genre);
        void Update(UpdateGenreCommand genre);
        void Delete(Genre genre);
    }
}

using TFTDirecting.Commands;
using TFTDirecting.Database;

namespace TFTDirecting.Contracts
{
    public interface IGenreRepository
    {
        Genre GetById(int genreId);
        void Create(Genre genre);
        void Update(Genre genre);
        void Delete(Genre genre);
    }
}

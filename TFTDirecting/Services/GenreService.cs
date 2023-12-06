using TFTDirecting.Commands;
using TFTDirecting.Contracts;
using TFTDirecting.Repository;

namespace TFTDirecting.Services
{
    public class GenreService: IGenreService
    {
        private IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public void Create(CreateGenreCommand command)
        {
            _genreRepository.Create(command);
        }

        public void Delete(int genreId)
        {
            var genre = _genreRepository.GetById(genreId);
            _genreRepository.Delete(genre);
        }

        public void Update(int genreId, UpdateGenreCommand command)
        {
            _genreRepository.Update(command);
        }
    }
}

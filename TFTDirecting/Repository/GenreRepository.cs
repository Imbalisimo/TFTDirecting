using TFTDirecting.Commands;
using TFTDirecting.Contracts;
using TFTDirecting.Database;
using TFTDirecting.Dtos;

namespace TFTDirecting.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private IConfiguration _config;
        public GenreRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void Create(CreateGenreCommand genre)
        {
            using (var db = new MoviesDbContext(_config))
            {
                db.Genres.Add(genre.ToGenre(0));
                db.SaveChanges();
            }
        }

        public void Delete(Genre genre)
        {
            using (var db = new MoviesDbContext(_config))
            {
                db.Genres.Remove(genre);
                db.SaveChanges();
            }
        }

        public GenreDto GetById(int genreId)
        {
            using (var db = new MoviesDbContext(_config))
            {
                return (from genre in db.Genres
                       where genre.Id == genreId
                       select new GenreDto(genre)).SingleOrDefault();
            }
        }

        public void Update(int genreId, UpdateGenreCommand genre)
        {
            using (var db = new MoviesDbContext(_config))
            {
                var updatingGenre = (from g in db.Genres
                                     where g.Id == genreId
                                     select g).SingleOrDefault();

                genre.UpdateGenre(updatingGenre);
                db.SaveChanges();
            }
        }
    }
}

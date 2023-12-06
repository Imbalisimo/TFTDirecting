using TFTDirecting.Commands;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using TFTDirecting.Database;
using Microsoft.AspNetCore.Mvc;

namespace TFTDirecting.Contracts
{
    public interface IGenreService
    {
        void Create(CreateGenreCommand command);
        void Update(int genreId, UpdateGenreCommand command);
        void Delete(int genreId);
    }
}

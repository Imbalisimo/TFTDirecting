using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFTDirecting.Commands;
using TFTDirecting.Contracts;
using TFTDirecting.Database;

namespace TFTDirecting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        //[SuperAdmin]
        [HttpPost()] // 3. Super administrator; a. Kreiranje žanrova
        public IActionResult CreateNewGenre([FromBody] CreateGenreCommand command)
        {
            _genreService.Create(command);
            return Ok();
        }

        //[SuperAdmin]
        [HttpPut("{genreId}")] // 3. Super administrator; c. Ažuriranje žanrova
        public IActionResult UpdateGenre(int genreId, [FromBody] UpdateGenreCommand command)
        {
            _genreService.Update(genreId, command);
            return Ok();
        }

        //[SuperAdmin]
        [HttpDelete("{genreId}")] // 3. Super administrator; b. Brisanje žanrova
        public IActionResult DeleteGenre(int genreId)
        {
            _genreService.Delete(genreId);
            return Ok();
        }
    }
}

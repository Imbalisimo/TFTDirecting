﻿using Microsoft.AspNetCore.Mvc;
using TFTDirecting.Commands;
using TFTDirecting.Contracts;
using TFTDirecting.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TFTDirecting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //[Actor]
        [HttpGet()] // 2. Glumac; f. Pregled svih filmova koji pripadaju pojedinom žanru; i. Filtriranje prema žanru/datumu početka/datumu kraju
        public IActionResult GetMovies([FromBody] MovieFilter filter)
        {
            return Ok(_movieService.GetMovies(filter));
        }

        //[Director]
        [HttpGet("{movieId}")] // 1. Direktor; b. Pregled pojedinog Filma
        public IActionResult GetMovie(int movieId)
        {
            return Ok(_movieService.GetMovieById(movieId));
        }

        //[HttpGet("director/{directorId}")] // 1. Direktor; a. Pregled svih mojih filmova; ii. Filtriranje filma prema žanrovima/budžetu/datumu početka/datumu kraja
                                           // 2. Glumac; e. Pregled svih filmova od pojedinog direktora; i. Filtriranje prema žanru/datumu početka/datumu kraja
        public IActionResult GetMoviesByDirector(int directorId, [FromBody] MovieFilter filter)
        {
            return Ok(_movieService.GetMoviesByDirector(directorId, filter));
        }

        //[Director]
        [HttpPost] // 1. Direktor; c. Kreiranje Filma
        public IActionResult AddNewMovie([FromBody] AddMovieCommand command)
        {
            _movieService.Add(command);
            return Ok();
        }

        //[Director]
        [HttpPut("{movieId}")] // 1. Direktor; e. Ažuriranje Filma
        public IActionResult UpdateMovie(int movieId, [FromBody] UpdateMovieCommand command)
        {
            _movieService.Update(movieId, command);
            return Ok();
        }

        //[Director]
        [HttpDelete("{movieId}")] // 1. Direktor; d. Brisanje Filma
        public IActionResult Delete(int movieId)
        {
            _movieService.Delete(movieId);
            return Ok();
        }
    }
}
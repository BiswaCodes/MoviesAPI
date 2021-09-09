using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.API.Contracts;
using Movies.API.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        public static IEnumerable<MovieEntity> Movies { get; set; }

        private readonly IMovieProvider _movieProvider;

        public MoviesController(IMovieProvider movieProvider)
        {
            _movieProvider = movieProvider;
        }

        [HttpGet]
        public IActionResult Get(int page)
        {
            var res = _movieProvider.Get(page);   ;
            return Ok(res);
        }

        [HttpGet("Id:int")]
        public async Task<IActionResult> GetMovieAsync(int Id)
        {
            var res = await _movieProvider.GetMovieAsync(Id);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult AddMovies([FromBody]MovieEntity movieEntity)
        { 
            return Ok(_movieProvider.AddMovies(movieEntity));
        }
    }
}
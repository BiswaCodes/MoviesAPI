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
    [Route("Api/[controller]")]
    public class MoviesController : ControllerBase
    {
        public static IEnumerable<MovieEntity> Movies { get; set; }

        private readonly IMovieProvider _movieProvider;

        public MoviesController(IMovieProvider movieProvider)
        {
            _movieProvider = movieProvider;
        }

        [HttpGet]
        [Route("/GetMovies")]
        public IActionResult Get([FromQuery]PagingParams pagingParams)
        {
            var res = _movieProvider.Get(pagingParams);   ;
            return Ok(res);
        }

        [HttpGet]
        [Route("/GetMovieAsync")]
        public async Task<IActionResult> GetMovieAsync(int Id)
        {
            var res = await _movieProvider.GetMovieAsync(Id);
            return Ok(res);
        }

        [HttpPost]
        [Route("/AddMovies")]
        public IActionResult AddMovies([FromBody]MovieEntity movieEntity)
        { 
            return Ok(_movieProvider.AddMovies(movieEntity));
        }
    }
}
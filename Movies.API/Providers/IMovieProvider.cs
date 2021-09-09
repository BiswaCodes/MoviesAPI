using Movies.API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Providers
{
    public interface IMovieProvider
    {
        IEnumerable<MovieEntity> Get(int page);

        Task<MovieEntity> GetMovieAsync(int Id);

        int AddMovies(MovieEntity movieEntity);
    }
}

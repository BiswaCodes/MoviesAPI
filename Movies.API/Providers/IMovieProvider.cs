using Movies.API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Providers
{
    public interface IMovieProvider
    {
        IEnumerable<MovieEntity> Get(PagingParams pagingParams);

        Task<MovieEntity> GetMovieAsync(int Id);

        int AddMovies(MovieEntity movieEntity);
    }
}

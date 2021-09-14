using Movies.API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Providers
{
    public class MoviesProvider : IMovieProvider
    {
        private int MovieCounter;

        public int AddMovies(MovieEntity movieEntity)
        {
            var existingMovies = this.ExistingMovies();
            movieEntity.Id = MovieCounter;
            MovieCounter++;
            existingMovies.Add(movieEntity);

            return movieEntity.Id;
        }

        public IEnumerable<MovieEntity> Get(PagingParams pagingParams)
        {
            var existingMovies = this.ExistingMovies();

            return existingMovies.Skip((pagingParams.PageNumber -1) * pagingParams.PageSize).Take(pagingParams.PageSize);
        }

        public async Task<MovieEntity> GetMovieAsync(int Id)
        {
            var existingMovies = this.ExistingMovies();
            return await Task.Run(() => existingMovies.FirstOrDefault(a => a.Id == Id));
        }

        private List<MovieEntity> ExistingMovies()
        {
            List<MovieEntity> Movies = new List<MovieEntity>
            {
                new MovieEntity { Id = 1, Title = "Toy Story 1", Director = "John Lasseter" },
                new MovieEntity { Id = 2, Title = "Toy Story 4", Director = "Josh Cooley" },
                new MovieEntity { Id = 3, Title = "Arrival", Director = "Denis Villeneuve" },
                new MovieEntity { Id = 4, Title = "Interstellar", Director = "Christopher Nolan" },
                new MovieEntity { Id = 5, Title = "The Martian", Director = "Ridley Scott" },

                new MovieEntity { Id = 6, Title = "Avatar", Director = "James Cameron" },
                new MovieEntity { Id = 7, Title = "Prometheus", Director = "Ridley Scott" },
                new MovieEntity { Id = 8, Title = "Sunshine", Director = "Danny Boyle" },

                new MovieEntity { Id = 9, Title = "Serenity", Director = "Joss Whedon" },
                new MovieEntity { Id = 10, Title = "WALL-E", Director = "Andrew Stanton" },
            };

            return Movies;
        }
    }
}

using Movie.API.Controllers;
using Movies.API.Contracts;
using Movies.API.Providers;
using NUnit.Framework;
using Xunit;

namespace Movies.Api.Test
{
    [TestFixture]
    public class MovieControllerTest
    {
        private MoviesController _moviesController;

        private readonly IMovieProvider _movieProvider;

        [SetUp]
        public void Initialize()
        {
            _moviesController = new MoviesController(_movieProvider);
        }

        [TearDown]
        public void CleanUp()
        {
            _moviesController = null;
        }

        [Test]
        public void Get_Test()
        {
            var result = _moviesController.Get(0);
            Assert.NotNull(result);
        }

        [Test]
        public void GetMovie_Test()
        {
            var result = _moviesController.GetMovieAsync(4);
            Assert.NotNull(result);
        }

        [Test]
        public void AddMovies_Test()
        {
            MovieEntity movieEntity = new MovieEntity {Title = "IRON MAN", Director = "Stan Lee" };
            var result = _moviesController.AddMovies(movieEntity);
            Assert.NotNull(result);
        }
    }
}
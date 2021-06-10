using NinjaPlus.Common;
using NinjaPlus.Lib;
using NinjaPlus.Pages;
using NUnit.Framework;

namespace NinjaPlus.Tests
{
    public class SearchMovieTests : BaseTest
    {
        private MoviePage _movie;
        private LoginPage _login;

        [SetUp]
        public void Before()
        {
            _login = new LoginPage(Browser);
            _movie = new MoviePage(Browser);

            _login.With("ganzenmuller1997@gmail.com", "Cel15996995309");

            Database.InsertMovies();
        }


        [Test]
        public void ShouldFindUniqueMovie()
        {
            var target = "Coringa";
            _movie.Search(target);

            Assert.That(_movie.HasMovie(target),
            $"Erro ao verificar se o filme {target} foi cadastrado.");

            Browser.HasNoContent("Puxa! não encontramos nada aqui :(");

            Assert.AreEqual(1, _movie.CountMovie());
        }

        [Test]
        public void ShouldFindMovies()
        {
            var target = "Batman";
            _movie.Search(target);

            Assert.That(_movie.HasMovie("Batman Begins"),
            $"Erro ao verificar se o filme {target} foi cadastrado.");

            Assert.That(_movie.HasMovie("Batman O Cavaleiro das Trevas"),
            $"Erro ao verificar se o filme {target} foi cadastrado.");

            Browser.HasNoContent("Puxa! não encontramos nada aqui :(");

            Assert.AreEqual(2, _movie.CountMovie());
        }

        [Test]
        public void ShouldDisplayNoMoviesFound()
        {
            _movie.Search("Os Trapalhões");

            Assert.AreEqual("Puxa! não encontramos nada aqui :(", _movie.SearchAlert());
        }
    }
}
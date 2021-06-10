using System;
using System.Threading;
using NinjaPlus.Common;
using NinjaPlus.Lib;
using NinjaPlus.Models;
using NinjaPlus.Pages;
using NUnit.Framework;

namespace NinjaPlus.Tests{
    public class SaveMovieTest : BaseTest{

        private LoginPage _login;
        private MoviePage _movie;

        [SetUp]
        public void Before()
        {
            _login = new LoginPage(Browser);
            _movie = new MoviePage(Browser);
            _login.With("ganzenmuller1997@gmail.com", "Cel15996995309");
        }


        [Test]
        public void ShouldSaveMovie()
        {
            

            var movieData = new MovieModel()
            {
            Title = "Resident Evil",
            Status = "Disponível",
            Year = 2002,
            ReleaseDate = "01/05/2002",
            Cast = {"Milla Jovovich", "Ali Larter", "Ian Glen", "Shawn Roberts"},
            Plot = "A missão do esquadrao e da Alice é desligar a Rainha Vermelha e coletar dados sobre o incidente.",
            Cover = CoverPath() + "resident-evil-2002.jpg"
            };

            Database.RemoveByTitle(movieData.Title);


            _movie.Add();
            _movie.Save(movieData);
            
            Assert.That(_movie.HasMovie(movieData.Title),
            $"Erro ao verificar se o filme {movieData.Title} foi cadastrado.");
        }
    }
}
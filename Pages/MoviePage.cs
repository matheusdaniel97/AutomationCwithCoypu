using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Coypu;
using NinjaPlus.Models;
using OpenQA.Selenium;

namespace NinjaPlus.Pages
{
    public class MoviePage
    {
        private readonly BrowserSession _browser;
        public MoviePage(BrowserSession browser)
        {
            _browser = browser;
        }
        public void Add()
        {
            _browser.FindCss(".movie-add").Click();
        }

        private void SelectStatus(string status)
        {
            _browser.FindCss("input[placeholder=Status]").Click();
            var option = _browser.FindCss("ul li span", text: status);
            option.Click();
        }

        private void InputCast(List<string> cast){
            //No caso abaixo será usado uma expressão regular onde ao passar "$=" no valor do atributo html, simboliza que o atributo deverá finalizar com aquele valor
            //$= finaliza com a palavra
            //^= Inicia com a palavra
            //*= Contém a palavra
            var element = _browser.FindCss("input[placeholder$=ator]");

            foreach(var actor in cast)
            {
                element.SendKeys(actor);
                element.SendKeys(Keys.Tab);
                Thread.Sleep(500); //Thinking time
            }
        }

        private void UploadCover(string cover)
        {
            var jsScript = "document.getElementById('upcover').classList.remove('el-upload__input');";
            _browser.ExecuteScript(jsScript);
            _browser.FindCss("#upcover").SendKeys(cover);
        }

        public void Save(MovieModel movie)
        {

            _browser.FindCss("input[name=title]").SendKeys(movie.Title);

            //_browser.Select("opção").From("Seletor_Do_Elemento") código para select comum
            SelectStatus(movie.Status);

            _browser.FindCss("input[name=year]").SendKeys(movie.Year.ToString());

            _browser.FindCss("input[name=release_date]").SendKeys(movie.ReleaseDate);

            InputCast(movie.Cast);

            _browser.FindCss("textarea[name=overview]").SendKeys(movie.Plot);

            UploadCover(movie.Cover);

            _browser.ClickButton("Cadastrar");

        }

        public bool HasMovie(string title)
        {
            return _browser.FindCss("table tbody tr", text: title).Exists();
        }

        public int CountMovie()
        {
            return _browser.FindAllCss("table tbody tr").Count();
        }

        public string SearchAlert()
        {
            return _browser.FindCss(".alert-dark").Text;
        }

        public void Search(string value)
        {
            _browser.FindCss("input[placeholder^=Pesquisar]").SendKeys(value);
            _browser.FindId("search-movie").Click();
        }
    }
}
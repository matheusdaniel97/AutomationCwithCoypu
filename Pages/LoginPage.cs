

using Coypu;

namespace NinjaPlus.Pages
{
    public class LoginPage
    {
        private readonly BrowserSession _browser;

        public LoginPage(BrowserSession browser)
        {
            _browser = browser;
        }

        public void Load()
        {
            _browser.Visit("/login");
        }
        
        public void With(string email, string senha)
        {
            this.Load();
            _browser.FillIn("email").With(email); //FillIn só é válido com name, id e label
            _browser.FindCss("input[placeholder=senha]").SendKeys(senha); //Quando não há name, id ou label
            _browser.ClickButton("Entrar");
        }

        public string AlertMessage()
        {
            return _browser.FindCss(".alert-dismissible span b").Text;
        }
        
    }
}
using NUnit.Framework;
using NinjaPlus.Pages;
using NinjaPlus.Common;

namespace NinjaPlus.Tests
{
    public class LoginTests : BaseTest
    {
        private LoginPage _login;
        private Sidebar _side;

        [SetUp]
        public void Start()
        {
            _login = new LoginPage(Browser);
            _side = new Sidebar(Browser);
        }

        [Test]
        [Category("Critical")]
        public void ShouldSeeLoggedUser()
        {
            _login.With("ganzenmuller1997@gmail.com", "Cel15996995309");
            Assert.AreEqual("Matheus Daniel", _side.LoggedUser());            
        }

        [TestCase("ganzenmuller1997@gmail.com", "invalid", "Usuário e/ou senha inválidos")]
        [TestCase("invalid@gmail.com", "Cel15996995309", "Usuário e/ou senha inválidos")]
        [TestCase("", "Cel15996995309", "Opps. Cadê o email?")]
        [TestCase("ganzenmuller1997@gmail.com", "", "Opps. Cadê a senha?")]
        public void ShouldSeeAlertMessage(string email, string pass, string expectMessage)
        {
            _login.With(email, pass);
            Assert.AreEqual(expectMessage, _login.AlertMessage());
        }
    }
}
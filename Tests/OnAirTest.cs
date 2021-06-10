using NUnit.Framework;
using NinjaPlus.Common;

namespace NinjaPlus.Tests //Namespace padrão
{
    public class OnAirTest: BaseTest //Classe sempre com o mesmo nome do arquivo
    {

        [Test]
        [Category("Smoke")]
        public void ShouldBeHaveTitle()
        {
            Browser.Visit("/login");
            Assert.AreEqual("Ninja+", Browser.Title);
        }

    }
}
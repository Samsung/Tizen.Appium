using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class TableViewTest1 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "TabelViewTest1.png";
            Driver.CheckScreenshot(image);
        }
    }
}

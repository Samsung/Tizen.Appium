using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewTest6 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "ListViewTest6.png";
            Driver.CheckScreenshot(image);
        }
    }
}

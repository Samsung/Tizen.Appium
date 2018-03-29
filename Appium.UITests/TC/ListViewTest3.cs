using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewTest3 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "ListViewTest3.png";
            Driver.CheckScreenshot(image);
        }
    }
}

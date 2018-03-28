using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewTest2 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "ListViewTest2.png";
            Driver.CheckScreenshot(image);
        }
    }
}

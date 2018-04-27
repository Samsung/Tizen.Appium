using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewTest3 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            System.Threading.Thread.Sleep(3000);
            var image = "ListViewTest3.png";
            Driver.CheckScreenshot(image);
        }
    }
}

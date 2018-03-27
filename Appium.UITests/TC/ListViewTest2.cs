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
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

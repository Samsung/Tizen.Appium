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
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

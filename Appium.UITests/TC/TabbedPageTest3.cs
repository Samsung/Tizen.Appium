using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class TabbedPageTest3 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var firstBtnId = "first1";

            Driver.Click(firstBtnId);

            var image = "TabbedPageTest3.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class TabbedPageBarBackgroundColor : TestTemplate
    {
        [Test]
        public void ChangeTitleTest()
        {
            var btnId = "changeTitle";

            Driver.Click(btnId);

            var image = "TabbedPageBarBackgroundColor_changeTitle.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void ChangeBackgroundTest()
        {
            var btnId = "changeBackground";

            Driver.Click(btnId);

            var image = "TabbedPageBarBackgroundColor_changeBackground.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

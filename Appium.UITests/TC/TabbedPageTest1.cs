using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class TabbedPageTest1 : TestTemplate
    {
        [Test]
        public void ShowHideTest()
        {
            var hideBtnId = "hide";
            var showBtnId = "show";

            Driver.Click(showBtnId);

            Driver.Click(hideBtnId);
            var image = "TabbedPageTest1_hide.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void ShowHideTest2()
        {
            var hideBtnId = "hide";
            var showBtnId = "show";

            Driver.Click(showBtnId);

            var image = "TabbedPageTest1_show.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

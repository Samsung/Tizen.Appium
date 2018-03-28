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
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void ShowHideTest2()
        {
            var showBtnId = "show";

            Driver.Click(showBtnId);

            var image = "TabbedPageTest1_show.png";
            Driver.CheckScreenshot(image);
        }
    }
}

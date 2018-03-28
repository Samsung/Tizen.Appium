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
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void ChangeBackgroundTest()
        {
            var btnId = "changeBackground";

            Driver.Click(btnId);

            var image = "TabbedPageBarBackgroundColor_changeBackground.png";
            Driver.CheckScreenshot(image);
        }
    }
}

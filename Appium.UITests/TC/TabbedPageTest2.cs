using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class TabbedPageTest2 : TestTemplate
    {
        [Test]
        public void ChangeTitleTest()
        {
            var changeBtnId = "chageTitle";

            Driver.Click(changeBtnId);

            var image = "TabbedPageTest2.png";
            Driver.CheckScreenshot(image);
        }
    }
}

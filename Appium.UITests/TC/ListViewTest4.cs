using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewTest4 : TestTemplate
    {
        [Test]
        public void SelectItemTest()
        {
            var btnId = "setButton";

            Driver.Click(btnId);

            var image = "ListViewTest4_setButton.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void SelectGroupTest()
        {
            var btnId = "setButton2";

            Driver.Click(btnId);

            var image = "ListViewTest4_setButton2.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void SelectGroupItemTest()
        {
            var btnId = "setButton3";

            Driver.Click(btnId);

            var image = "ListViewTest4_setButton3.png";
            Driver.CheckScreenshot(image);
        }
    }
}

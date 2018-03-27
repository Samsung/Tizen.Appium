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

            // screenshot
        }

        [Test]
        public void SelectGroupTest()
        {
            var btnId = "setButton2";

            Driver.Click(btnId);
            // screenshot
        }

        [Test]
        public void SelectGroupItemTest()
        {
            var btnId = "setButton3";

            Driver.Click(btnId);

            // screenshot
        }
    }
}

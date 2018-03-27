using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class NavigationTest1 : TestTemplate
    {
        [Test]
        public void BarColorChangeTest()
        {
            var btnId = "barColorChanged";

            Driver.Click(btnId);

            var image = "NavigationTest1_barColorChanged.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));

            Driver.Click(btnId);
        }

        [Test]
        public void BarVisibleTest()
        {
            var btnId = "BarVisible";

            Driver.Click(btnId);

            var image = "NavigationTest1_BarVisible.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));

            Driver.Click(btnId);
        }
    }
}

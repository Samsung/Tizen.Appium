using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class RecalculateTest1 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "RecalculateTest1.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void ViewTest1()
        {
            var pickerid = "button";
            Driver.Click(pickerid);

            var image = "RecalculateTest1_clear.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

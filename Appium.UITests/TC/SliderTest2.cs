using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class SliderTest2 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var btnId = "button2";

            Driver.Click(btnId);

            var image = "SliderTest2.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

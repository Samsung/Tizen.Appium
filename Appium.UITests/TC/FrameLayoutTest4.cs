using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class FrameLayoutTest4 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var paddingSliderId = "sliderPadding";
            var marginSliderId = "sliderMargin";

            Driver.SetAttribute(paddingSliderId, "Value", 100);
            Driver.SetAttribute(marginSliderId, "Value", 100);

            var image = "FrameLayoutTest4.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

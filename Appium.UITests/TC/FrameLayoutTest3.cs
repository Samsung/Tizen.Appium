using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class FrameLayoutTest3 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var sliderId = "sliderH";

            Driver.SetAttribute(sliderId, "Value", 0.3);

            var image = "FrameLayoutTest3.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

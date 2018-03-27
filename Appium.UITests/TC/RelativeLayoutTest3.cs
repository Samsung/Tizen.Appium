using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class RelativeLayoutTest3 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "RelativeLayoutTest3.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void ChangeMarginTest()
        {
            var sliderId = "sliderMargin";

            Driver.SetAttribute(sliderId, "Value", 100);

            var image = "RelativeLayoutTest3_sliderMargin.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void ChangePaddingTest()
        {
            var sliderId = "sliderPadding";

            Driver.SetAttribute(sliderId, "Value", 100);

            var image = "RelativeLayoutTest3_sliderPadding.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

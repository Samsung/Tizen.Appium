using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class StackLayoutTest8 : TestTemplate
    {
        [Test]
        public void OrientationTest()
        {
            var btnId = "buttonOrientation";
            var resetBtnId = "buttonReset";

            Driver.Click(btnId);

            var image = "StackLayoutTest8_orientation.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));

            Driver.Click(resetBtnId);
        }

        [Test]
        public void ViewTest()
        {
            var paddingSlider = "sliderPadding";
            var spacingSlider = "sliderSpacing";
            var marginSlider = "sliderMargin";

            Driver.SetAttribute(paddingSlider, "Value", 100);
            Driver.SetAttribute(spacingSlider, "Value", 100);
            Driver.SetAttribute(marginSlider, "Value", 100);

            var image = "StackLayoutTest8.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

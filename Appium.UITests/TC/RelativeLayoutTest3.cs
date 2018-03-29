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
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void ChangeMarginTest()
        {
            var sliderId = "sliderMargin";

            Driver.SetAttribute(sliderId, "Value", 100);

            var image = "RelativeLayoutTest3_sliderMargin.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void ChangePaddingTest()
        {
            var sliderId = "sliderPadding";

            Driver.SetAttribute(sliderId, "Value", 100);

            var image = "RelativeLayoutTest3_sliderPadding.png";
            Driver.CheckScreenshot(image);
        }
    }
}

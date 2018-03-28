using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class StackLayoutTest6 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "StackLayoutTest6.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void ChangeOrientationTest()
        {
            var btnId = "orientaionChangeButton";

            Driver.Click(btnId);

            var image = "StackLayoutTest6_orientation.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void ChangePaddingSpacingTest()
        {
            var btnId = "orientaionChangeButton";
            var paddingSliderId = "paddingSlider";
            var spacingSliderId = "spacingSlider";

            Driver.Click(btnId);

            Driver.SetAttribute(paddingSliderId, "Value", 100);
            Driver.SetAttribute(spacingSliderId, "Value", 100);

            var image = "StackLayoutTest6_padding.png";
            Driver.CheckScreenshot(image);
        }
    }
}

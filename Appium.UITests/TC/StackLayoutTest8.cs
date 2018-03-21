using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class StackLayoutTest8
    {
        string PlatformName;
        AppiumDriver Driver;

        public StackLayoutTest8(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);
            FormsTizenGalleryUtils.FindTC(Driver, this.GetType().Name);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void OrientationTest()
        {
            var btnId = "buttonOrientation";
            var resetBtnId = "buttonReset";

            WebElementUtils.Click(Driver, btnId);

            //screenshot

            WebElementUtils.Click(Driver, resetBtnId);
        }

        [Test]
        public void ViewTest()
        {
            var paddingSlider = "sliderPadding";
            var spacingSlider = "sliderSpacing";
            var marginSlider = "sliderMargin";

            WebElementUtils.SetAttribute(Driver, paddingSlider, "Value", 100);
            WebElementUtils.SetAttribute(Driver, spacingSlider, "Value", 100);
            WebElementUtils.SetAttribute(Driver, marginSlider, "Value", 100);

            //screenshot
        }
    }
}

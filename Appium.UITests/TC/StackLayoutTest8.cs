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
        public void PaddingTest()
        {
            var sliderId = "sliderPadding";
            var resetBtnId = "buttonReset";

            //set sliderPadding

            //screenshot

            WebElementUtils.Click(Driver, resetBtnId);
        }

        [Test]
        public void SpacingTest()
        {
            var sliderId = "sliderSpacing";
            var resetBtnId = "buttonReset";

            //set sliderSpacing

            //screenshot

            WebElementUtils.Click(Driver, resetBtnId);
        }

        [Test]
        public void MarginTest()
        {
            var btnId = "sliderMargin";
            var resetBtnId = "buttonReset";

            WebElementUtils.Click(Driver, btnId);

            //screenshot

            WebElementUtils.Click(Driver, resetBtnId);
        }
    }
}

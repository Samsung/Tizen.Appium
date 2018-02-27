using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class StackLayoutTest6
    {
        string PlatformName;
        AppiumDriver Driver;

        public StackLayoutTest6(string platform)
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
        public void ViewTest()
        {
            //screenshot
        }

        [Test]
        public void ChangeOrientationTest()
        {
            var btnId = "orientaionChangeButton";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void ChangePaddingSpacingTest()
        {
            var btnId = "orientaionChangeButton";
            var paddingSliderId = "paddingSlider";
            var spacingSliderId = "spacingSlider";

            WebElementUtils.Click(Driver, btnId);

            var remoteTouch = new RemoteTouchScreenUtils(Driver);

            //setvalue paddingSlider
            //setvalue spacingSlider

            //screenshot
        }
    }
}

using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class RelativeLayoutTest3
    {
        string PlatformName;
        AppiumDriver Driver;

        public RelativeLayoutTest3(string platform)
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
        public void ChangeMarginTest()
        {
            var sliderId = "sliderMargin";

            //screenshot
            //setvalue
            //screenshot
        }

        [Test]
        public void ChangePaddingTest()
        {
            var sliderId = "sliderPadding";

            //screenshot
            //setvalue
            //screenshot
        }
    }
}

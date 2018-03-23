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
            var image = "RelativeLayoutTest3.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void ChangeMarginTest()
        {
            var sliderId = "sliderMargin";

            WebElementUtils.SetAttribute(Driver, sliderId, "Value", 100);

            var image = "RelativeLayoutTest3_sliderMargin.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void ChangePaddingTest()
        {
            var sliderId = "sliderPadding";

            WebElementUtils.SetAttribute(Driver, sliderId, "Value", 100);

            var image = "RelativeLayoutTest3_sliderPadding.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }
    }
}

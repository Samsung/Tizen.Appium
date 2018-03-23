using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ScrollViewTest3
    {
        string PlatformName;
        AppiumDriver Driver;

        public ScrollViewTest3(string platform)
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
            var scrollViewId = "scrollView";

            var xBefore = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollX");
            var yBefore = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollY");

            WebElementUtils.Click(Driver, "button");

            var xAfter = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollX");
            var yAfter = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollY");

            Assert.True((xBefore < xAfter), "X value should be increased, but got before: " + xBefore + ", after: " + xAfter);
            Assert.True((yBefore < yAfter), "y value should be increased, but got before: " + yBefore + ", after: " + yAfter);

            var image = "ScrollViewTest3.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }
    }
}

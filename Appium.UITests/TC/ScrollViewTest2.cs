using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ScrollViewTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public ScrollViewTest2(string platform)
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

            WebElementUtils.Click(Driver, "button");

            var xAfter = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollX");

            Assert.True((xBefore < xAfter), "X value should be increased, but got before: " + xBefore + ", after: " + xAfter);

            var image = "ScrollViewTest2.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }
    }
}

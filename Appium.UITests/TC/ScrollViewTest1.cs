using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ScrollViewTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public ScrollViewTest1(string platform)
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
            var remoteTouch = new RemoteTouchScreenUtils(Driver);

            var yBefore = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollY");

            WebElementUtils.Click(Driver, "button");

            var yAfter = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollY");

            Assert.True((yBefore < yAfter), "Y value should be incresed, but got before: " + yBefore + ", after: " + yAfter);

            var image = "ScrollViewTest1.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }
    }
}

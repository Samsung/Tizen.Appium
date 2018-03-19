using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ScrollViewTest5
    {
        string PlatformName;
        AppiumDriver Driver;

        public ScrollViewTest5(string platform)
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
            var scrollView = "scrollView";
            var remoteTouch = new RemoteTouchScreenUtils(Driver);

            var yBefore = WebElementUtils.GetAttribute<double>(Driver, scrollView, "ScrollY");

            remoteTouch.Flick(0, -3);

            var yAfter = WebElementUtils.GetAttribute<double>(Driver, scrollView, "ScrollY");

            Assert.True((yBefore < yAfter), "Y value should be increased, but got before: " + yBefore + ", after: " + yAfter);

            //screenshot
        }
    }
}

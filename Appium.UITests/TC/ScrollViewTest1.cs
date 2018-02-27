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

            var yBefore = WebElementUtils.GetAttribute(Driver, scrollViewId, "ScrollY");

            remoteTouch.Flick(0, -3);

            var yAfter = WebElementUtils.GetAttribute(Driver, scrollViewId, "ScrollY");

            Assert.True((Convert.ToDouble(yBefore) < Convert.ToDouble(yAfter)), "Y value should be incresed, but got before: " + yBefore + ", after: " + yAfter);

            //screenshot
        }
    }
}

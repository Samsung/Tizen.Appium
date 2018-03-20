using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ScrollViewTest4
    {
        string PlatformName;
        AppiumDriver Driver;

        public ScrollViewTest4(string platform)
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
        public void VerticalScrollTest()
        {
            var btnId = "button";
            var scrollViewId = "scrollView";
            var remoteTouch = new RemoteTouchScreenUtils(Driver);

            var layout = WebElementUtils.GetAttribute<string>(Driver, scrollViewId, "Content");
            while (layout != "vLayout")
            {
                WebElementUtils.Click(Driver, btnId);
                layout = WebElementUtils.GetAttribute<string>(Driver, scrollViewId, "Content");
            }

            var xBefore = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollX");
            var yBefore = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollY");

            remoteTouch.Flick(0, -3);

            var xAfter = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollX");
            var yAfter = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollY");

            Assert.True((xBefore == xAfter), "X value should not be changed, but got before: " + xBefore + ", after: " + xAfter);
            Assert.True((yBefore < yAfter), "Y value should be changed, but got before: " + yBefore + ", after: " + yAfter);
            //screenshot
        }

        [Test]
        public void HorizontalScrollTest()
        {
            var btnId = "button";
            var scrollViewId = "scrollView";
            var remoteTouch = new RemoteTouchScreenUtils(Driver);

            var layout = WebElementUtils.GetAttribute<string>(Driver, scrollViewId, "Content");
            while (layout != "hLayout")
            {
                WebElementUtils.Click(Driver, btnId);
                layout = WebElementUtils.GetAttribute<string>(Driver, scrollViewId, "Content");
            }

            var xBefore = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollX");
            var yBefore = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollY");

            remoteTouch.Flick(-3, 0);

            var xAfter = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollX");
            var yAfter = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollY");

            Assert.True((xBefore < xAfter), "X value should be changed, but got before: " + xBefore + ", after: " + xAfter);
            Assert.True((yBefore == yAfter), "Y value should not be changed, but got before: " + yBefore + ", after: " + yAfter);

            //screenshot
        }
    }
}

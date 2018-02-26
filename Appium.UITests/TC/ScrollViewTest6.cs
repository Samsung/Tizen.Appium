using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ScrollViewTest6
    {
        string PlatformName;
        AppiumDriver Driver;

        public ScrollViewTest6(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);
            FormsTizenGalleryUtils.FindTC(Driver, this.GetType().Name);

            var horizontalAddBtnId = "horizontalAddButton";
            var verticallAddBtnId = "verticallAddButton";

            WebElementUtils.Click(Driver, horizontalAddBtnId);
            WebElementUtils.Click(Driver, horizontalAddBtnId);
            WebElementUtils.Click(Driver, horizontalAddBtnId);

            WebElementUtils.Click(Driver, verticallAddBtnId);
            WebElementUtils.Click(Driver, verticallAddBtnId);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void ScrollWithoutAnimationTest()
        {
            var scrollBtnId = "scrollButton";
            var remoteTouch = new RemoteTouchScreenUtils(Driver);

            remoteTouch.Drag(150, 150, 100, 100);

            WebElementUtils.Click(Driver, scrollBtnId);
            //screenshot
        }

        [Test]
        public void ScrollAnimationTest()
        {
            var scrollBtnId = "scrollButtonAnimation";
            var remoteTouch = new RemoteTouchScreenUtils(Driver);

            remoteTouch.Drag(150, 150, 100, 100);

            WebElementUtils.Click(Driver, scrollBtnId);
            //screenshot
        }

        [Test]
        public void ScrollBothTest()
        {
            var scrollViewId = "scrollView";
            var scrollBtnId = "scrollButtonAnimation";
            var scrollOrientationBtnId = "orientationButton";

            var remoteTouch = new RemoteTouchScreenUtils(Driver);

            var orientation = WebElementUtils.GetAttribute(Driver, scrollViewId, "Orientation");
            while (orientation != "Both")
            {
                WebElementUtils.Click(Driver, scrollOrientationBtnId);
                orientation = WebElementUtils.GetAttribute(Driver, scrollViewId, "Orientation");
            }

            remoteTouch.Drag(150, 150, 100, 100);

            //screenshot

            WebElementUtils.Click(Driver, scrollBtnId);
        }

        [Test]
        public void ScrollVerticalTest()
        {
            var scrollViewId = "scrollView";
            var scrollBtnId = "scrollButtonAnimation";
            var scrollOrientationBtnId = "orientationButton";

            var remoteTouch = new RemoteTouchScreenUtils(Driver);

            var orientation = WebElementUtils.GetAttribute(Driver, scrollViewId, "Orientation");
            while (orientation != "Vertical")
            {
                WebElementUtils.Click(Driver, scrollOrientationBtnId);
                orientation = WebElementUtils.GetAttribute(Driver, scrollViewId, "Orientation");
            }

            remoteTouch.Drag(150, 150, 100, 100);

            //screenshot

            WebElementUtils.Click(Driver, scrollBtnId);
        }

        [Test]
        public void ScrollHorizontalTest()
        {
            var scrollViewId = "scrollView";
            var scrollBtnId = "scrollButtonAnimation";
            var scrollOrientationBtnId = "orientationButton";

            var remoteTouch = new RemoteTouchScreenUtils(Driver);

            var orientation = WebElementUtils.GetAttribute(Driver, scrollViewId, "Orientation");
            while (orientation != "Horizontal")
            {
                WebElementUtils.Click(Driver, scrollOrientationBtnId);
                orientation = WebElementUtils.GetAttribute(Driver, scrollViewId, "Orientation");
            }

            remoteTouch.Drag(150, 150, 100, 100);

            //screenshot

            WebElementUtils.Click(Driver, scrollBtnId);
        }
    }
}

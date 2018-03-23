using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class NavigationModalAsyncTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public NavigationModalAsyncTest1(string platform)
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
        public void PushAndPopTest()
        {
            var pushBtn = "pushBtn_1";
            var popBtnId = "popBtn_2";

            var depthBefore = GetNavigationStackDepth();

            WebElementUtils.Click(Driver, pushBtn);

            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore == depthAfter), "StackDepth should be same, but got before: " + depthBefore + ", after: " + depthAfter);

            var image = "NavigationModalAsyncTest1_pushAndPop.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));

            WebElementUtils.Click(Driver, popBtnId);
        }

        [Test]
        public void PopPushTest()
        {
            var popAndPushBtnId = "PopAndPush_1";

            var depthBefore = GetNavigationStackDepth();

            WebElementUtils.Click(Driver, popAndPushBtnId);

            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore == depthAfter), "StackDepth should be same, but got before: " + depthBefore + ", after: " + depthAfter);

            var image = "NavigationModalAsyncTest1_popPush.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void PushPopTest()
        {
            var pushAndPopBtnId = "pushAndPop_1";

            var depthBefore = GetNavigationStackDepth();

            WebElementUtils.Click(Driver, pushAndPopBtnId);

            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore == depthAfter), "StackDepth should be same, but got before: " + depthBefore + ", after: " + depthAfter);

            var image = "NavigationModalAsyncTest1_pushPop.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void PushPushTest()
        {
            var pushPushBtnId = "pushpush_1";
            var popBtn3Id = "popBtn_3";
            var popBtn2Id = "popBtn_2";

            var depthBefore = GetNavigationStackDepth();

            WebElementUtils.Click(Driver, pushPushBtnId);

            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore == depthAfter), "StackDepth should be same, but got before: " + depthBefore + ", after: " + depthAfter);

            var image = "NavigationModalAsyncTest1_pushPush.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));

            WebElementUtils.Click(Driver, popBtn3Id);
            WebElementUtils.Click(Driver, popBtn2Id);
        }

        int GetNavigationStackDepth()
        {
            var depth = WebElementUtils.GetAttribute(Driver, "MainPage", "StackDepth");
            return Convert.ToInt32(depth);
        }
    }
}

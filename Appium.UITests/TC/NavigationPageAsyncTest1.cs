using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class NavigationPageAsyncTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public NavigationPageAsyncTest1(string platform)
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
            var pushBtnId = "pushBtn_1";
            var popBtnId = "popBtn_2";

            var depthBefore = GetNavigationStackDepth();

            WebElementUtils.Click(Driver, pushBtnId);
            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore < depthAfter), "StackDepth should be increased, but got before: " + depthBefore + ", after: " + depthAfter);

            var image = "NavigationPageAsyncTest1_pushAndPop.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));

            WebElementUtils.Click(Driver, popBtnId);
            depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore == depthAfter), "StackDepth should be decreased, but got before: " + depthBefore + ", after: " + depthAfter);

            var image2 = "NavigationPageAsyncTest1_pushAndPop2.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image2);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image2));
        }

        [Test]
        public void PushPopTest()
        {
            var pushAndPopBtnId = "pushAndPop_1";

            var depthBefore = GetNavigationStackDepth();

            WebElementUtils.Click(Driver, pushAndPopBtnId);
            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore == depthAfter), "StackDepth should be same, but got before: " + depthBefore + ", after: " + depthAfter);

            var image = "NavigationPageAsyncTest1_pushPop.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void PushPushTest()
        {
            var pushPushBtnId = "pushpush_1";
            var popPopBtnId = "poppop_3";

            var depthBefore = GetNavigationStackDepth();

            WebElementUtils.Click(Driver, pushPushBtnId);
            var depthAfter = GetNavigationStackDepth();
            Assert.True(((depthBefore + 2) == depthAfter), "StackDepth should be increased, but got before: " + depthBefore + ", after: " + depthAfter);

            //var image = "NavigationPageAsyncTest1_pushPush.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            //Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));

            //pop and pop issue
            WebElementUtils.Click(Driver, popPopBtnId);
            depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore == depthAfter), "StackDepth should be decreased, but got before: " + depthBefore + ", after: " + depthAfter);

            //screenshot crash app
            //var image2 = "NavigationPageAsyncTest1_pushPushPopPop2.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image2);
            //Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image2));
        }

        [Test]
        public void PopPushTest()
        {
            var pushBtnId = "pushBtn_1";
            var popPushBtnId = "PopAndPush_2";

            var depthBefore = GetNavigationStackDepth();

            WebElementUtils.Click(Driver, pushBtnId);
            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore < depthAfter), "StackDepth should be increased, but got before: " + depthBefore + ", after: " + depthAfter);

            var image = "NavigationPageAsyncTest1_popPush.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));

            depthBefore = depthAfter;
            WebElementUtils.Click(Driver, popPushBtnId);
            Assert.True((depthBefore == depthAfter), "StackDepth should be same, but got before: " + depthBefore + ", after: " + depthAfter);

            var image2 = "NavigationPageAsyncTest1_popPush2.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image2);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image2));
        }

        [Test]
        public void PopToRootTest()
        {
            var popToRootBtnId = "popToRoot_1";

            var depthBefore = GetNavigationStackDepth();

            WebElementUtils.Click(Driver, popToRootBtnId);
            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore > depthAfter), "StackDepth should be decreased, but got before: " + depthBefore + ", after: " + depthAfter);

            var image = "NavigationPageAsyncTest1_popToRoot.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));

            FormsTizenGalleryUtils.FindTC(Driver, this.GetType().Name);
        }

        int GetNavigationStackDepth()
        {
            var depth = WebElementUtils.GetAttribute(Driver, "MainPage", "StackDepth");
            return Convert.ToInt32(depth);
        }
    }
}

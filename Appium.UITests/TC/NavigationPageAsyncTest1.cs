using NUnit.Framework;
using System;

namespace Appium.UITests
{
    [TestFixture]
    public class NavigationPageAsyncTest1 : TestTemplate
    {
        [Test]
        public void PushAndPopTest()
        {
            var pushBtnId = "pushBtn_1";
            var popBtnId = "popBtn_2";

            var depthBefore = GetNavigationStackDepth();

            Driver.Click(pushBtnId);
            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore < depthAfter), "StackDepth should be increased, but got before: " + depthBefore + ", after: " + depthAfter);

            var image = "NavigationPageAsyncTest1_pushAndPop.png";
            Driver.CheckScreenshot(image);

            Driver.Click(popBtnId);
            depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore == depthAfter), "StackDepth should be decreased, but got before: " + depthBefore + ", after: " + depthAfter);

            var image2 = "NavigationPageAsyncTest1_pushAndPop2.png";
            Driver.CheckScreenshot(image2);
        }

        [Test]
        public void PushPopTest()
        {
            var pushAndPopBtnId = "pushAndPop_1";

            var depthBefore = GetNavigationStackDepth();

            Driver.Click(pushAndPopBtnId);
            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore == depthAfter), "StackDepth should be same, but got before: " + depthBefore + ", after: " + depthAfter);

            var image = "NavigationPageAsyncTest1_pushPop.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void PushPushTest()
        {
            var pushPushBtnId = "pushpush_1";
            //var popPopBtnId = "poppop_3";

            var depthBefore = GetNavigationStackDepth();

            Driver.Click(pushPushBtnId);
            var depthAfter = GetNavigationStackDepth();
            Assert.True(((depthBefore + 2) == depthAfter), "StackDepth should be increased, but got before: " + depthBefore + ", after: " + depthAfter);

            var image = "NavigationPageAsyncTest1_pushPush.png";
            Driver.CheckScreenshot(image);

            //pop and pop issue
            //Driver.Click(popPopBtnId);
            //depthAfter = GetNavigationStackDepth();
            //Assert.True((depthBefore == depthAfter), "StackDepth should be decreased, but got before: " + depthBefore + ", after: " + depthAfter);

            //screenshot crash app
            //var image2 = "NavigationPageAsyncTest1_pushPushPopPop2.png";
            //Driver.GetScreenshotAndSave(image2);
            ////Assert.AreEqual(true, Driver.CompareToScreenshot(image2));
        }

        [Test]
        public void PopPushTest()
        {
            var pushBtnId = "pushBtn_1";
            var popPushBtnId = "PopAndPush_2";

            var depthBefore = GetNavigationStackDepth();

            Driver.Click(pushBtnId);
            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore < depthAfter), "StackDepth should be increased, but got before: " + depthBefore + ", after: " + depthAfter);

            var image = "NavigationPageAsyncTest1_popPush.png";
            Driver.CheckScreenshot(image);

            depthBefore = depthAfter;
            Driver.Click(popPushBtnId);
            Assert.True((depthBefore == depthAfter), "StackDepth should be same, but got before: " + depthBefore + ", after: " + depthAfter);

            var image2 = "NavigationPageAsyncTest1_popPush2.png";
            Driver.CheckScreenshot(image2);
        }

        [Test]
        public void PopToRootTest()
        {
            var popToRootBtnId = "popToRoot_1";

            var depthBefore = GetNavigationStackDepth();

            Driver.Click(popToRootBtnId);
            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore > depthAfter), "StackDepth should be decreased, but got before: " + depthBefore + ", after: " + depthAfter);

            Driver.FindTC(this.GetType().Name);
            //FormsTizenGalleryUtils.FindTC(Driver, this.GetType().Name);
        }

        int GetNavigationStackDepth()
        {
            var depth = Driver.GetAttribute<int>("MainPage", "StackDepth");
            return depth;
        }
    }
}

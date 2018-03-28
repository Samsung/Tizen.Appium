using NUnit.Framework;
using System;

namespace Appium.UITests
{
    [TestFixture]
    public class NavigationModalAsyncTest1 : TestTemplate
    {
        [Test]
        public void PushAndPopTest()
        {
            var pushBtn = "pushBtn_1";
            var popBtnId = "popBtn_2";

            var depthBefore = GetNavigationStackDepth();

            Driver.Click(pushBtn);

            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore == depthAfter), "StackDepth should be same, but got before: " + depthBefore + ", after: " + depthAfter);

            var image = "NavigationModalAsyncTest1_pushAndPop.png";
            Driver.CheckScreenshot(image);

            Driver.Click(popBtnId);
        }

        [Test]
        public void PopPushTest()
        {
            var popAndPushBtnId = "PopAndPush_1";

            var depthBefore = GetNavigationStackDepth();

            Driver.Click(popAndPushBtnId);

            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore == depthAfter), "StackDepth should be same, but got before: " + depthBefore + ", after: " + depthAfter);

            var image = "NavigationModalAsyncTest1_popPush.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void PushPopTest()
        {
            var pushAndPopBtnId = "pushAndPop_1";

            var depthBefore = GetNavigationStackDepth();

            Driver.Click(pushAndPopBtnId);

            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore == depthAfter), "StackDepth should be same, but got before: " + depthBefore + ", after: " + depthAfter);

            var image = "NavigationModalAsyncTest1_pushPop.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void PushPushTest()
        {
            var pushPushBtnId = "pushpush_1";
            var popBtn3Id = "popBtn_3";
            var popBtn2Id = "popBtn_2";

            var depthBefore = GetNavigationStackDepth();

            Driver.Click(pushPushBtnId);

            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore == depthAfter), "StackDepth should be same, but got before: " + depthBefore + ", after: " + depthAfter);

            var image = "NavigationModalAsyncTest1_pushPush.png";
            Driver.CheckScreenshot(image);

            Driver.Click(popBtn3Id);
            Driver.Click(popBtn2Id);
        }

        int GetNavigationStackDepth()
        {
            var depth = Driver.GetAttribute<int>("MainPage", "StackDepth");
            return depth;
        }
    }
}

using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ScrollViewTest6 : TestTemplate
    {
        [Test]
        public void ScrollWithoutAnimationTest()
        {
            var scrollBtnId = "scrollButton";

            Driver.Drag(150, 150, 100, 100);

            Driver.Click(scrollBtnId);
            //screenshot
        }

        [Test]
        public void ScrollAnimationTest()
        {
            var scrollBtnId = "scrollButtonAnimation";

            Driver.Drag(150, 150, 100, 100);

            Driver.Click(scrollBtnId);
            //screenshot
        }

        [Test]
        public void ScrollBothTest()
        {
            var scrollViewId = "scrollView";
            var scrollBtnId = "scrollButtonAnimation";
            var scrollOrientationBtnId = "orientationButton";

            var orientation = Driver.GetAttribute<string>(scrollViewId, "Orientation");
            while (orientation != "Both")
            {
                Driver.Click(scrollOrientationBtnId);
                orientation = Driver.GetAttribute<string>(scrollViewId, "Orientation");
            }

            Driver.Drag(150, 150, 100, 100);

            //screenshot

            Driver.Click(scrollBtnId);
        }

        [Test]
        public void ScrollVerticalTest()
        {
            var scrollViewId = "scrollView";
            var scrollBtnId = "scrollButtonAnimation";
            var scrollOrientationBtnId = "orientationButton";

            var orientation = Driver.GetAttribute<string>(scrollViewId, "Orientation");
            while (orientation != "Vertical")
            {
                Driver.Click(scrollOrientationBtnId);
                orientation = Driver.GetAttribute<string>(scrollViewId, "Orientation");
            }

            Driver.Drag(150, 150, 100, 100);

            //screenshot

            Driver.Click(scrollBtnId);
        }

        [Test]
        public void ScrollHorizontalTest()
        {
            var scrollViewId = "scrollView";
            var scrollBtnId = "scrollButtonAnimation";
            var scrollOrientationBtnId = "orientationButton";

            var orientation = Driver.GetAttribute<string>(scrollViewId, "Orientation");
            while (orientation != "Horizontal")
            {
                Driver.Click(scrollOrientationBtnId);
                orientation = Driver.GetAttribute<string>(scrollViewId, "Orientation");
            }

            Driver.Drag(150, 150, 100, 100);

            //screenshot

            Driver.Click(scrollBtnId);
        }
    }
}

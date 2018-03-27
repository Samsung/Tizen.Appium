using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ScrollViewTest4 : TestTemplate
    {
        [Test]
        public void VerticalScrollTest()
        {
            var btnId = "button";
            var scrollViewId = "scrollView";

            var layout = Driver.GetAttribute<string>(scrollViewId, "Content");
            while (layout != "vLayout")
            {
                Driver.Click(btnId);
                layout = Driver.GetAttribute<string>(scrollViewId, "Content");
            }

            var xBefore = Driver.GetAttribute<double>(scrollViewId, "ScrollX");
            var yBefore = Driver.GetAttribute<double>(scrollViewId, "ScrollY");

            Driver.Flick(0, -3);

            var xAfter = Driver.GetAttribute<double>(scrollViewId, "ScrollX");
            var yAfter = Driver.GetAttribute<double>(scrollViewId, "ScrollY");

            Assert.True((xBefore == xAfter), "X value should not be changed, but got before: " + xBefore + ", after: " + xAfter);
            Assert.True((yBefore < yAfter), "Y value should be changed, but got before: " + yBefore + ", after: " + yAfter);
            //screenshot
        }

        [Test]
        public void HorizontalScrollTest()
        {
            var btnId = "button";
            var scrollViewId = "scrollView";

            var layout = Driver.GetAttribute<string>(scrollViewId, "Content");
            while (layout != "hLayout")
            {
                Driver.Click(btnId);
                layout = Driver.GetAttribute<string>(scrollViewId, "Content");
            }

            var xBefore = Driver.GetAttribute<double>(scrollViewId, "ScrollX");
            var yBefore = Driver.GetAttribute<double>(scrollViewId, "ScrollY");

            Driver.Flick(-3, 0);

            var xAfter = Driver.GetAttribute<double>(scrollViewId, "ScrollX");
            var yAfter = Driver.GetAttribute<double>(scrollViewId, "ScrollY");

            Assert.True((xBefore < xAfter), "X value should be changed, but got before: " + xBefore + ", after: " + xAfter);
            Assert.True((yBefore == yAfter), "Y value should not be changed, but got before: " + yBefore + ", after: " + yAfter);

            //screenshot
        }
    }
}

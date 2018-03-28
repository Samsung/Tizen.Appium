using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ScrollViewTest2 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var scrollViewId = "scrollView";

            var xBefore = Driver.GetAttribute<double>(scrollViewId, "ScrollX");

            Driver.Flick(-3, 0);

            var xAfter = Driver.GetAttribute<double>(scrollViewId, "ScrollX");

            Assert.True((xBefore < xAfter), "X value should be increased, but got before: " + xBefore + ", after: " + xAfter);
        }
    }
}

using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ScrollViewTest3 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var scrollViewId = "scrollView";

            var xBefore = Driver.GetAttribute<double>(scrollViewId, "ScrollX");
            var yBefore = Driver.GetAttribute<double>(scrollViewId, "ScrollY");

            Driver.Flick(-3, -3);

            var xAfter = Driver.GetAttribute<double>(scrollViewId, "ScrollX");
            var yAfter = Driver.GetAttribute<double>(scrollViewId, "ScrollY");

            Assert.True((xBefore < xAfter), "X value should be increased, but got before: " + xBefore + ", after: " + xAfter);
            Assert.True((yBefore < yAfter), "y value should be increased, but got before: " + yBefore + ", after: " + yAfter);

            var image = "ScrollViewTest3.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

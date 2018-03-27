using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ScrollViewTest1 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var scrollViewId = "scrollView";

            var yBefore = Driver.GetAttribute<double>(scrollViewId, "ScrollY");

            Driver.Flick(0, -3);

            var yAfter = Driver.GetAttribute<double>(scrollViewId, "ScrollY");

            Assert.True((yBefore < yAfter), "Y value should be incresed, but got before: " + yBefore + ", after: " + yAfter);

            var image = "ScrollViewTest1.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

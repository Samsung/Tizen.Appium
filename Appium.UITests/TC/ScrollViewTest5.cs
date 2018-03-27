using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ScrollViewTest5 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var scrollView = "scrollView";

            var yBefore = Driver.GetAttribute<double>(scrollView, "ScrollY");

            Driver.Flick(0, -3);

            var yAfter = Driver.GetAttribute<double>(scrollView, "ScrollY");

            Assert.True((yBefore < yAfter), "Y value should be increased, but got before: " + yBefore + ", after: " + yAfter);

            //screenshot
        }
    }
}

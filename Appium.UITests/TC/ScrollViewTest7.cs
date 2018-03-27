using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ScrollViewTest7 : TestTemplate
    {
        [Test]
        public void RandomScrollTest()
        {
            var randomScrollBtnId = "button";
            var scrollViewId = "scrollView";

            var yBefore = Driver.GetAttribute<double>(scrollViewId, "ScrollY");

            Driver.Click(randomScrollBtnId);

            var yAfter = Driver.GetAttribute<double>(scrollViewId, "ScrollY");

            Assert.True((yBefore < yAfter), "Y value should be incresed, but got before: " + yBefore + ", after: " + yAfter);
            //screenshot
        }
    }
}

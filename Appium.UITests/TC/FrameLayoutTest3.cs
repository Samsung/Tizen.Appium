using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class FrameLayoutTest3 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            //var sliderId = "sliderH";

            //Driver.SetAttribute(sliderId, "Value", 1);

            var image = "FrameLayoutTest3.png";
            Driver.CheckScreenshot(image);
        }
    }
}

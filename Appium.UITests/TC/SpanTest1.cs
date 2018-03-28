using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class SpanTest1 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "SpanTest1.png";
            Driver.CheckScreenshot(image);
        }
    }
}

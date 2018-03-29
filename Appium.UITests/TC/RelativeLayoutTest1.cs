using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class RelativeLayoutTest1 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "RelativeLayoutTest1.png";
            Driver.CheckScreenshot(image);
        }
    }
}

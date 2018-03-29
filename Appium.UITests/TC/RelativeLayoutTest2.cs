using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class RelativeLayoutTest2 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "RelativeLayoutTest2.png";
            Driver.CheckScreenshot(image);
        }
    }
}

using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class StackLayoutTest1 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "StackLayoutTest1.png";
            Driver.CheckScreenshot(image);
        }
    }
}

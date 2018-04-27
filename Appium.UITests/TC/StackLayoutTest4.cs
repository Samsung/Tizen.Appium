using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class StackLayoutTest4 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "StackLayoutTest4.png";
            Driver.CheckScreenshot(image);
        }
    }
}

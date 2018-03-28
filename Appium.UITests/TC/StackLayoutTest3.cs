using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class StackLayoutTest3 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "StackLayoutTest3.png";
            Driver.CheckScreenshot(image);
        }
    }
}

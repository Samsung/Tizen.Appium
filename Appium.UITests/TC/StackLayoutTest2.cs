using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class StackLayoutTest2 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "StackLayoutTest2.png";
            Driver.CheckScreenshot(image);
        }
    }
}

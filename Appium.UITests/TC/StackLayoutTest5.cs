using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class StackLayoutTest5 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "StackLayoutTest5.png";
            Driver.CheckScreenshot(image);
        }
    }
}

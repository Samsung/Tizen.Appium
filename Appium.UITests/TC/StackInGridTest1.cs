using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class StackInGridTest1 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "StackInGridTest1.png";
            System.Threading.Thread.Sleep(1500);
            Driver.CheckScreenshot(image);
        }
    }
}

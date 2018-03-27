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
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

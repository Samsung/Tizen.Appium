using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class OpacityTest1 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "OpacityTest1.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

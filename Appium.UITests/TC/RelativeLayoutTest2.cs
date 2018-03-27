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
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

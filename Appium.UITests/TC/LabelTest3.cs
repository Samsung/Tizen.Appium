using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class LabelTest3 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "LabelTest3.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

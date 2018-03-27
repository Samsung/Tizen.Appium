using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class LabelTest5 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "LabelTest5.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

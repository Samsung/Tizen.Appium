using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class TableViewTest5 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var enableBtnId = "enble";

            var image = "TabelViewTest5.png";

            Driver.Click(enableBtnId);
            //WebElementUtils.GetScreenshotAndSave(Driver, imageName);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

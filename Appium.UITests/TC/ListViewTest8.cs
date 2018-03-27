using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewTest8 : TestTemplate
    {
        [Test]
        public void AddRemoveTest()
        {
            var btnId = "button";

            Driver.Click(btnId);

            var image = "ListViewTest8.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));

            Driver.Click(btnId);

            var image2 = "ListViewTest8_2.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image2);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image2));
        }
    }
}

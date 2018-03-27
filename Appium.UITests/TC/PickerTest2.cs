using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class PickerTest2 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var pickerid = "picker";

            Driver.Click(pickerid);

            var image = "PickerTest2.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

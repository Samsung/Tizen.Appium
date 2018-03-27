using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class LayoutAddRemoveTest : TestTemplate
    {
        [Test]
        public void AddTest()
        {
            var addBtnId = "addbtn";

            Driver.Click(addBtnId);

            var image = "LayoutAddRemoveTest_addbtn.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void AddRemoveTest()
        {
            var addBtnId = "addbtn";
            var removeBtnId = "removebtn";

            Driver.Click(addBtnId);
            Driver.Click(removeBtnId);

            var image = "LayoutAddRemoveTest_removebtn.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

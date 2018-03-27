using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class TabbedPageTest4 : TestTemplate
    {
        [Test]
        public void InsertBeforeTest()
        {
            var insertBeforeBtnId = "insertBeforeButton_1";

            Driver.Click(insertBeforeBtnId);

            var image = "TabbedPageTest4_insertBeforeButton_1.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void InsertBeforeTest2()
        {
            var insertAfterBtnId = "insertAfterButton_1";

            Driver.Click(insertAfterBtnId);

            var image = "TabbedPageTest4_insertAfterButton_1.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void InsertBeforeTest3()
        {
            var removeBtnId = "removeButton_1";

            Driver.Click(removeBtnId);

            var image = "TabbedPageTest4_removeButton_1.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class TableViewTest2 : TestTemplate
    {
        [Test]
        public void AddRemoveSectionTest()
        {
            var addSectionBtnId = "addSectionBtn";

            Driver.Click(addSectionBtnId);
            var addSectionImage = "TabelViewTest2_addSection.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, addSectionImage);
            Assert.AreEqual(true, Driver.CompareToScreenshot(addSectionImage));
        }

        [Test]
        public void AddRemoveSectionTest2()
        {
            var removeSectionBtnId = "removeSectionBtn";

            Driver.Click(removeSectionBtnId);
            var removeSectionImage = "TabelViewTest2_removeSection.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, removeSectionImage);
            Assert.AreEqual(true, Driver.CompareToScreenshot(removeSectionImage));
        }

        [Test]
        public void AddRemoveSectionTest3()
        {
            var addSectionBtnId = "addSectionBtn";
            var removeAllSectionBtnId = "removeAllSectionBtn";

            Driver.Click(addSectionBtnId);
            Driver.Click(removeAllSectionBtnId);
            var removeAllSectionImage = "TabelViewTest2_removeAllSection.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, removeAllSectionImage);
            Assert.AreEqual(true, Driver.CompareToScreenshot(removeAllSectionImage));
        }

        [Test]
        public void AddRemoveCellTest()
        {
            var addSectionBtnId = "addSectionBtn";
            var addCellBtnId = "addCellBtn";

            Driver.Click(addSectionBtnId);
            Driver.Click(addCellBtnId);
            var addImage = "TabelViewTest2_add.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, addImage);
            Assert.AreEqual(true, Driver.CompareToScreenshot(addImage));
        }

        [Test]
        public void AddRemoveCellTest2()
        {
            var removeCellBtnId = "removeCellBtn";

            Driver.Click(removeCellBtnId);
            var removeImage = "TabelViewTest2_remove.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, removeImage);
            Assert.AreEqual(true, Driver.CompareToScreenshot(removeImage));
        }
    }
}

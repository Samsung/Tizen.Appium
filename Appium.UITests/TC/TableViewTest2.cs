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

            var image = "TabelViewTest2_addSection.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void AddRemoveSectionTest2()
        {
            var removeSectionBtnId = "removeSectionBtn";

            Driver.Click(removeSectionBtnId);

            var image = "TabelViewTest2_removeSection.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void AddRemoveSectionTest3()
        {
            var addSectionBtnId = "addSectionBtn";
            var removeAllSectionBtnId = "removeAllSectionBtn";

            Driver.Click(addSectionBtnId);
            Driver.Click(removeAllSectionBtnId);

            var image = "TabelViewTest2_removeAllSection.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void AddRemoveCellTest()
        {
            var addSectionBtnId = "addSectionBtn";
            var addCellBtnId = "addCellBtn";

            Driver.Click(addSectionBtnId);
            Driver.Click(addCellBtnId);

            var image = "TabelViewTest2_add.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void AddRemoveCellTest2()
        {
            var removeCellBtnId = "removeCellBtn";

            Driver.Click(removeCellBtnId);

            var image = "TabelViewTest2_remove.png";
            Driver.CheckScreenshot(image);
        }
    }
}

using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class TableViewTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public TableViewTest2(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);
            FormsTizenGalleryUtils.FindTC(Driver, this.GetType().Name);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void AddRemoveSectionTest()
        {
            var addSectionBtnId = "addSectionBtn";

            WebElementUtils.Click(Driver, addSectionBtnId);
            var addSectionImage = "TabelViewTest2_addSection.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, addSectionImage);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, addSectionImage));
        }

        [Test]
        public void AddRemoveSectionTest2()
        {
            var removeSectionBtnId = "removeSectionBtn";

            WebElementUtils.Click(Driver, removeSectionBtnId);
            var removeSectionImage = "TabelViewTest2_removeSection.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, removeSectionImage);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, removeSectionImage));
        }

        [Test]
        public void AddRemoveSectionTest3()
        {
            var addSectionBtnId = "addSectionBtn";
            var removeAllSectionBtnId = "removeAllSectionBtn";

            WebElementUtils.Click(Driver, addSectionBtnId);
            WebElementUtils.Click(Driver, removeAllSectionBtnId);
            var removeAllSectionImage = "TabelViewTest2_removeAllSection.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, removeAllSectionImage);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, removeAllSectionImage));
        }

        [Test]
        public void AddRemoveCellTest()
        {
            var addSectionBtnId = "addSectionBtn";
            var addCellBtnId = "addCellBtn";

            WebElementUtils.Click(Driver, addSectionBtnId);
            WebElementUtils.Click(Driver, addCellBtnId);
            var addImage = "TabelViewTest2_add.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, addImage);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, addImage));
        }

        [Test]
        public void AddRemoveCellTest2()
        {
            var removeCellBtnId = "removeCellBtn";

            WebElementUtils.Click(Driver, removeCellBtnId);
            var removeImage = "TabelViewTest2_remove.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, removeImage);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, removeImage));
        }
    }
}

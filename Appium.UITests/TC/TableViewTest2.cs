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
            var removeSectionBtnId = "removeSectionBtn";
            var removeAllSectionBtnId = "removeAllSectionBtn";

            WebElementUtils.Click(Driver, addSectionBtnId);
            //screenshot

            WebElementUtils.Click(Driver, removeSectionBtnId);
            //screenshot

            WebElementUtils.Click(Driver, addSectionBtnId);
            WebElementUtils.Click(Driver, removeAllSectionBtnId);
            //screenshot
        }

        [Test]
        public void AddRemoveCellTest()
        {
            var addSectionBtnId = "addSectionBtn";
            var addCellBtnId = "addCellBtn";
            var removeCellBtnId = "removeCellBtn";

            WebElementUtils.Click(Driver, addSectionBtnId);
            WebElementUtils.Click(Driver, addCellBtnId);
            //screenshot

            WebElementUtils.Click(Driver, removeCellBtnId);
            //screenshot
        }
    }
}

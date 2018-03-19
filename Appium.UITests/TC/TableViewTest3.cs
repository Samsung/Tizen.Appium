using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class TableViewTest3
    {
        string PlatformName;
        AppiumDriver Driver;

        public TableViewTest3(string platform)
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
        public void ViewTest()
        {
            var tableViewId = "table";
            var changeHasUnevenCellBtnId = "change";
            var plusRowHeightBtnId = "+10";
            var minusRowHeightBtnId = "-10";

            var hasUnevenCell = WebElementUtils.GetAttribute<bool>(Driver, tableViewId, "HasUnevenRows");
            if (!hasUnevenCell)
            {
                WebElementUtils.Click(Driver, changeHasUnevenCellBtnId);
            }

            WebElementUtils.Click(Driver, plusRowHeightBtnId);
            //screenshot

            WebElementUtils.Click(Driver, minusRowHeightBtnId);
            //screenshot
        }
    }
}

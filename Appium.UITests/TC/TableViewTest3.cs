using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class TableViewTest3 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var tableViewId = "table";
            var changeHasUnevenCellBtnId = "change";
            var plusRowHeightBtnId = "+10";

            var hasUnevenCell = Driver.GetAttribute<bool>(tableViewId, "HasUnevenRows");
            if (!hasUnevenCell)
            {
                Driver.Click(changeHasUnevenCellBtnId);
            }

            Driver.Click(plusRowHeightBtnId);
            var plusImage = "TabelViewTest3_plus.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, plusImage);
            Assert.AreEqual(true, Driver.CompareToScreenshot(plusImage));
        }

        [Test]
        public void ViewTest2()
        {
            var minusRowHeightBtnId = "-10";
            Driver.Click(minusRowHeightBtnId);
            var minusImage = "TabelViewTest3_minus.png";
            //Driver.GetScreenshotAndSave(minusImage);
            Assert.AreEqual(true, Driver.CompareToScreenshot(minusImage));
        }
    }
}

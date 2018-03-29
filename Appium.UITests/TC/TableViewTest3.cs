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

            var image = "TabelViewTest3_plus.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void ViewTest2()
        {
            var minusRowHeightBtnId = "-10";
            Driver.Click(minusRowHeightBtnId);

            var image = "TabelViewTest3_minus.png";
            Driver.CheckScreenshot(image);
        }
    }
}

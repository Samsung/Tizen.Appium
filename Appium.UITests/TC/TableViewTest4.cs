using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class TableViewTest4 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var tableViewId = "table";
            var checkId = "check";
            var set0BtnId = "btnSet0";
            var setMinus1BtnId = "btnSet_minus1";
            var sliderId = "slider";

            var hasUnevenCell = Driver.GetAttribute<bool>(tableViewId, "HasUnevenRows");
            if (!hasUnevenCell)
            {
                Driver.Click(checkId);
            }

            Driver.Click(set0BtnId);

            Driver.SetAttribute(sliderId, "Value", 100);

            Driver.Click(setMinus1BtnId);

            var image = "TabelViewTest4.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, imageName);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}

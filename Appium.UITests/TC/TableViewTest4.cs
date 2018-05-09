using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class TableViewTest4 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var set0BtnId = "btnSet0";
            var setMinus1BtnId = "btnSet_minus1";
            var sliderId = "slider";

            Driver.Click(set0BtnId);

            Driver.SetAttribute(sliderId, "Value", 100);

            Driver.Click(setMinus1BtnId);

            var image = "TabelViewTest4.png";
            Driver.CheckScreenshot(image);
        }
    }
}

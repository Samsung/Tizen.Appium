using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class TableViewTest6 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var redBtnId = "red";

            Driver.Click(redBtnId);

            System.Threading.Thread.Sleep(2000);

            var image = "TableViewTest6_red.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void ViewTest2()
        {
            var greenBtnId = "green";

            Driver.Click(greenBtnId);

            var image = "TableViewTest6_green.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void ViewTest3()
        {
            var grayBtnId = "gray";

            Driver.Click(grayBtnId);

            var image = "TableViewTest6_gray.png";
            Driver.CheckScreenshot(image);
        }
    }
}

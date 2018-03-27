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
            var redImage = "TableViewTest6_red.png";

            Driver.Click(redBtnId);
            //WebElementUtils.GetScreenshotAndSave(Driver, redImage);

            Assert.AreEqual(true, Driver.CompareToScreenshot(redImage));
        }

        [Test]
        public void ViewTest2()
        {
            var greenBtnId = "green";
            var greenImage = "TableViewTest6_green.png";

            Driver.Click(greenBtnId);
            //WebElementUtils.GetScreenshotAndSave(Driver, greenImage);

            Assert.AreEqual(true, Driver.CompareToScreenshot(greenImage));
        }

        [Test]
        public void ViewTest3()
        {
            var grayBtnId = "gray";
            var grayImage = "TableViewTest6_gray.png";

            Driver.Click(grayBtnId);
            //WebElementUtils.GetScreenshotAndSave(Driver, grayImage);

            Assert.AreEqual(true, Driver.CompareToScreenshot(grayImage));
        }
    }
}

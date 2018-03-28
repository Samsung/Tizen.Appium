using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class RecalculateTest1 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "RecalculateTest1.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void ViewTest1()
        {
            var pickerid = "button";
            Driver.Click(pickerid);

            var image = "RecalculateTest1_clear.png";
            Driver.CheckScreenshot(image);
        }
    }
}

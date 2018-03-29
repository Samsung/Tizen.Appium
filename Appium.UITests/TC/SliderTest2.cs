using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class SliderTest2 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var btnId = "button2";

            Driver.Click(btnId);

            var image = "SliderTest2.png";
            Driver.CheckScreenshot(image);
        }
    }
}

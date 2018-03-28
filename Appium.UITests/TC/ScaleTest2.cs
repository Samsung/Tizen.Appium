using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ScaleTest2 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var btnId = "btn1";

            Driver.Click(btnId);

            var image = "ScaleTest2.png";
            Driver.CheckScreenshot(image);
        }
    }
}

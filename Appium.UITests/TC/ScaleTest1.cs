using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ScaleTest1 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var btnId = "btn";

            Driver.Click(btnId);

            var image = "ScaleTest1.png";
            Driver.CheckScreenshot(image);
        }
    }
}

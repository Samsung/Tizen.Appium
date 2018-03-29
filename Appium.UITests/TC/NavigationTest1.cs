using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class NavigationTest1 : TestTemplate
    {
        [Test]
        public void BarVisibleTest()
        {
            var btnId = "BarVisible";

            Driver.Click(btnId);

            var image = "NavigationTest1_BarVisible.png";
            Driver.CheckScreenshot(image);

            Driver.Click(btnId);
        }
    }
}

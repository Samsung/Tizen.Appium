using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewTest8 : TestTemplate
    {
        [Test]
        public void AddRemoveTest()
        {
            var btnId = "button";

            Driver.Click(btnId);
            System.Threading.Thread.Sleep(1500);

            var image = "ListViewTest8.png";
            Driver.CheckScreenshot(image);

            Driver.Click(btnId);

            var image2 = "ListViewTest8_2.png";
            Driver.CheckScreenshot(image2);
        }
    }
}

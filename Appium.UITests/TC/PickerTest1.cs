using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class PickerTest1 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var pickerid = "picker";

            Driver.Click(pickerid);

            System.Threading.Thread.Sleep(1000);

            var image = "PickerTest1.png";
            Driver.CheckScreenshot(image);
        }
    }
}

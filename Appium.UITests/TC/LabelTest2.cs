using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class LabelTest2 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "LabelTest2.png";
            Driver.CheckScreenshot(image);
        }
    }
}

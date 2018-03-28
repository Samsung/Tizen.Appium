using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class LabelTest3 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "LabelTest3.png";
            Driver.CheckScreenshot(image);
        }
    }
}

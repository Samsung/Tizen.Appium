using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class LabelTest5 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var image = "LabelTest5.png";
            Driver.CheckScreenshot(image);
        }
    }
}

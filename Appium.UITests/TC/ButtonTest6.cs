using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ButtonTest6 : TestTemplate
    {
        [Test]
        public void ClickTest()
        {
            string result = Driver.GetAttribute<string>("_button", "BackgroundColor");
            Assert.AreEqual("[Color: A=1, R=0.576470613479614, G=0.439215689897537, B=0.858823537826538, Hue=0.721183776855469, Saturation=0.597765326499939, Luminosity=0.649019598960876]", result);
        }
    }
}

using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class EntryTest3 : TestTemplate
    {
        [Test]
        public void TextChangedTest()
        {
            string add = "ABCDEFG";
            Driver.SetText("entry2", add);

            Driver.Click(240, 187);

            string result = Driver.GetText("entry");
            Assert.AreEqual("Text changed", result);
        }

        [Test]
        public void TextColorTest()
        {
            Driver.Click("bt");
            string result = Driver.GetAttribute<string>("entry2", "TextColor");
            Assert.AreEqual("[Color: A=1, R=0, G=0.501960813999176, B=0, Hue=0.333333343267441, Saturation=1, Luminosity=0.250980406999588]", result);
        }
    }
}

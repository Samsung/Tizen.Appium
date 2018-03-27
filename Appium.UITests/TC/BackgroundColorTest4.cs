using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class BackgroundColorTest4 : TestTemplate
    {
        [Test]
        public void LabelBackgroundTest()
        {
            Driver.Click("btnDefaultLabel");
            string result = Driver.GetAttribute<string>("label", "BackgroundColor");
            Driver.Click("btnRedLabel");
            string result2 = Driver.GetAttribute<string>("label", "BackgroundColor");
            Assert.AreNotEqual(result, result2);
        }

        [Test]
        public void ButtonBackgroundTest()
        {
            Driver.Click("btnDefaultButton");
            string result = Driver.GetAttribute<string>("button", "BackgroundColor");
            Driver.Click("btnBlueButton");
            string result2 = Driver.GetAttribute<string>("button", "BackgroundColor");
            Assert.AreNotEqual(result, result2);
        }
    }
}

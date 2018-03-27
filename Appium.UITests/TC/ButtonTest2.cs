using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ButtonTest2 : TestTemplate
    {
        [Test]
        public void ClickTest()
        {
            string before = Driver.GetAttribute<string>("btnColored", "TextColor");
            Driver.Click("btnColored");
            string after = Driver.GetAttribute<string>("btnColored", "TextColor");
            Assert.AreNotEqual(before, after);
        }

        [Test]
        public void ClickTest2()
        {
            bool before = Driver.GetAttribute<bool>("btnDisableTarget", "IsEnabled");
            Assert.AreEqual(false, before);

            Driver.Click("btnDisableToggle");

            bool after = Driver.GetAttribute<bool>("btnDisableTarget", "IsEnabled");
            Assert.AreEqual(true, after);
        }
    }
}

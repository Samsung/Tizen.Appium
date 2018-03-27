using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class SetColorTest : TestTemplate
    {
        [Test]
        public void ChangeColorTest()
        {
            var btnId = "button";
            string currentButton = Driver.GetAttribute<string>("button", "TextColor");
            string currentai = Driver.GetAttribute<string>("ai", "Color");
            string currentbv = Driver.GetAttribute<string>("bv", "Color");
            string currentst = Driver.GetAttribute<string>("st", "BackgroundColor");

            Driver.Click(btnId);

            string changedButton = Driver.GetAttribute<string>("button", "TextColor");
            string changedai = Driver.GetAttribute<string>("ai", "Color");
            string changedbv = Driver.GetAttribute<string>("bv", "Color");
            string changedst = Driver.GetAttribute<string>("st", "BackgroundColor");

            Assert.AreNotEqual(currentButton, changedButton);
            Assert.AreNotEqual(currentai, changedai);
            Assert.AreNotEqual(currentbv, changedbv);
            Assert.AreNotEqual(currentst, changedst);
        }
    }
}

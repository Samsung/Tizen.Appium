using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewTest14 : TestTemplate
    {
        [Test]
        public void DisableTest()
        {
            var enableBtnId = "disableButton";
            var itemId = "1 item";

            Driver.Click(itemId);
            Driver.Click(enableBtnId);

            var isEnabled = Driver.GetAttribute<bool>(itemId, "IsEnabled");
            Assert.False(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);
        }

        [Test]
        public void EnableTest()
        {
            var enableBtnId = "enableButton";
            var itemId = "0 item";

            Driver.Click(itemId);
            Driver.Click(enableBtnId);

            var isEnabled = Driver.GetAttribute<bool>(itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);
        }
    }
}

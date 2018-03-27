using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewTest13 : TestTemplate
    {
        [Test]
        public void DisableTest()
        {
            var disableBtnId = "disableButton";
            var itemId = "1 item";

            var isEnabled = Driver.GetAttribute<bool>(itemId, "On");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);

            Driver.Click(itemId);
            Driver.Click(disableBtnId);

            isEnabled = Driver.GetAttribute<bool>(itemId, "On");
            Assert.False(isEnabled, itemId + ".IsVisible should be false, but got " + isEnabled);
        }

        [Test]
        public void EnableTest()
        {
            var enableBtnId = "enableButton";
            var itemId = "0 item";

            var isEnabled = Driver.GetAttribute<bool>(itemId, "On");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);

            Driver.Click(itemId);
            Driver.Click(enableBtnId);

            isEnabled = Driver.GetAttribute<bool>(itemId, "On");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);
        }
    }
}

using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewTest7 : TestTemplate
    {
        [Test]
        public void AddRemoveTest()
        {
            var insertBtnId = "insertButton";
            var removeBtnId = "removeButton";
            var itemId = "Item added 2";

            Driver.Click(insertBtnId);

            var isEnabled = Driver.GetAttribute<bool>(itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);

            Driver.Click(itemId);
            Driver.Click(removeBtnId);

            isEnabled = Driver.GetAttribute<bool>(itemId, "IsEnabled");
            Assert.False(isEnabled, itemId + ".IsVisible should be false, but got " + isEnabled);
        }

        [Test]
        public void AddRemoveAllTest()
        {
            var insertBtnId = "insertButton";
            var removeAllBtnId = "removeAllButton";
            var itemId = "Item added 1";

            Driver.Click(insertBtnId);

            var isEnabled = Driver.GetAttribute<bool>(itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);

            Driver.Click(removeAllBtnId);

            isEnabled = Driver.GetAttribute<bool>(itemId, "IsEnabled");
            Assert.False(isEnabled, itemId + ".IsVisible should be false, but got " + isEnabled);
        }
    }
}

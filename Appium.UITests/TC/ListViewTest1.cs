using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewTest1 : TestTemplate
    {
        [Test]
        public void AddTest()
        {
            var btnId = "addBtn";
            var itemId = "item 3";

            Driver.Click(btnId);

            var isEnabled = Driver.GetAttribute<bool>(itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);
        }

        [Test]
        public void RemoveTest()
        {
            var btnId = "removeBtn";
            var itemId = "item 2";

            var isEnabled = Driver.GetAttribute<bool>(itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);

            Driver.Click(btnId);

            isEnabled = Driver.GetAttribute<bool>(itemId, "IsEnabled");
            Assert.False(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);
        }
    }
}

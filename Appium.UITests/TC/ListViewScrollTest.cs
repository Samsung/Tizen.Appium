using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewScrollTest : TestTemplate
    {
        [Test]
        public void Move1Test()
        {
            var btnId = "move1";
            var itemId = "item 1";

            Driver.Click(btnId);

            var isEnabled = Driver.GetAttribute<bool>(itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);
        }

        [Test]
        public void Move2Test()
        {
            var btnId = "move2";
            var itemId = "item 200";

            Driver.Click(btnId);

            var isEnabled = Driver.GetAttribute<bool>(itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);
        }

        [Test]
        public void Move3Test()
        {
            var btnId = "move3";
            var itemId = "item 999";

            Driver.Click(btnId);

            var isEnabled = Driver.GetAttribute<bool>(itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);
        }
    }
}

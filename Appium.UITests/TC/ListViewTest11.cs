using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewTest11 : TestTemplate
    {
        [Test]
        public void HasUnevenRowsTrueTest()
        {
            var listId = "listView";
            var checkId = "check";
            var sliderId = "slider";
            var itemId = "list item 1";

            var hasUnevenRows = Driver.GetAttribute<bool>(listId, "HasUnevenRows");
            if (!hasUnevenRows)
            {
                Driver.Click(checkId);
            }

            Driver.SetAttribute(sliderId, "Value", 300);

            var height = Driver.GetAttribute<double>(itemId, "Height");
            Assert.True((height == 300), "Height value should not be 300");
        }

        [Test]
        public void HasUnevenRowsFalseTest()
        {
            var listId = "listView";
            var checkId = "check";
            var sliderId = "slider";
            var itemId = "list item 1";

            var hasUnevenRows = Driver.GetAttribute<bool>(listId, "HasUnevenRows");
            if (hasUnevenRows)
            {
                Driver.Click(checkId);
            }

            Driver.SetAttribute(sliderId, "Value", 300);

            var height = Driver.GetAttribute<double>(itemId, "Height");
            Assert.True((height != 300), "Height value should be 300");
        }
    }
}

using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewTest5 : TestTemplate
    {
        [Test]
        public void SelectItemTest()
        {
            var selectLabelId = "label";
            var pressLabelId = "pressLabel";
            var itemId = "item1-1";

            var isEnabled = Driver.GetAttribute<bool>(itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);

            Driver.Click(itemId);

            var selected = Driver.GetAttribute<string>(selectLabelId, "Text");
            selected = selected.Substring(selected.IndexOf(":") + 1).TrimStart().TrimEnd();
            Assert.True((itemId == selected), itemId + " is expected, but got " + selected);

            var pressed = Driver.GetAttribute<string>(pressLabelId, "Text");
            pressed = pressed.Substring(pressed.IndexOf(":") + 1).TrimStart().TrimEnd();
            Assert.True((itemId == pressed), itemId + " is expected, but got " + pressed);
        }
    }
}

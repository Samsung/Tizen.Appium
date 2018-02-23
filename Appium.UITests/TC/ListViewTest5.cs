using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewTest5
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewTest5(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);
            FormsTizenGalleryUtils.FindTC(Driver, this.GetType().Name);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void SelectItemTest()
        {
            var listId = "list";
            var selectLabelId = "label";
            var pressLabelId = "pressLabel";
            var itemString = "item1-1";

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            Assert.False(String.IsNullOrEmpty(itemId), itemId + "should not be empty or null, but got " + itemId);

            WebElementUtils.Click(Driver, itemId);

            var selected = WebElementUtils.GetAttribute(Driver, selectLabelId, "Text");
            selected = selected.Substring(selected.IndexOf(":") + 1).TrimStart().TrimEnd();
            Assert.True((itemString == selected), itemString + " is expected, but got " + selected);

            var pressed = WebElementUtils.GetAttribute(Driver, pressLabelId, "Text");
            pressed = pressed.Substring(pressed.IndexOf(":") + 1).TrimStart().TrimEnd();
            Assert.True((itemString == pressed), itemString + " is expected, but got " + pressed);
        }
    }
}

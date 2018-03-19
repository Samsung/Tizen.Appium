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
            var selectLabelId = "label";
            var pressLabelId = "pressLabel";
            var itemId = "item1-1";

            var isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);

            WebElementUtils.Click(Driver, itemId);

            var selected = WebElementUtils.GetAttribute<string>(Driver, selectLabelId, "Text");
            selected = selected.Substring(selected.IndexOf(":") + 1).TrimStart().TrimEnd();
            Assert.True((itemId == selected), itemId + " is expected, but got " + selected);

            var pressed = WebElementUtils.GetAttribute<string>(Driver, pressLabelId, "Text");
            pressed = pressed.Substring(pressed.IndexOf(":") + 1).TrimStart().TrimEnd();
            Assert.True((itemId == pressed), itemId + " is expected, but got " + pressed);
        }
    }
}

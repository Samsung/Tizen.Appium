using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewTest1(string platform)
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
        public void AddTest()
        {
            var btnId = "addBtn";
            var itemId = "item 3";

            WebElementUtils.Click(Driver, btnId);

            var isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);
        }

        [Test]
        public void RemoveTest()
        {
            var btnId = "removeBtn";
            var itemId = "item 2";

            var isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);

            WebElementUtils.Click(Driver, btnId);

            isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            Assert.False(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);
        }
    }
}

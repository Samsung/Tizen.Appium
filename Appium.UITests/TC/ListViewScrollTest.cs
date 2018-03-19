using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewScrollTest
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewScrollTest(string platform)
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
        public void Move1Test()
        {
            var btnId = "move1";
            var itemId = "item 1";

            WebElementUtils.Click(Driver, btnId);

            var isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);
        }

        [Test]
        public void Move2Test()
        {
            var btnId = "move2";
            var itemId = "item 200";

            WebElementUtils.Click(Driver, btnId);

            var isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);
        }

        [Test]
        public void Move3Test()
        {
            var btnId = "move3";
            var itemId = "item 999";

            WebElementUtils.Click(Driver, btnId);

            var isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);
        }
    }
}

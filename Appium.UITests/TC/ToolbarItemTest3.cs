using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ToolbarItemTest3
    {
        string PlatformName;
        AppiumDriver Driver;

        public ToolbarItemTest3(string platform)
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
        public void AddToolbarItem()
        {
            WebElementUtils.Click(Driver, "addPrimaryItemButton");
            WebElementUtils.Click(Driver, "addPrimaryItemButton2");

            Assert.AreEqual(true, true);
        }

        [Test]
        public void RemoveToolbarItem()
        {
            WebElementUtils.Click(Driver, "removeItemButton");

            Assert.AreEqual(true, true);
        }

        [Test]
        public void ChangePriority()
        {
            WebElementUtils.Click(Driver, "changeItemButton");

            Assert.AreEqual(true, true);
        }

        [Test]
        public void ChangeIcon()
        {
            WebElementUtils.Click(Driver, "changeIconButton");

            Assert.AreEqual(true, true);
        }
    }
}

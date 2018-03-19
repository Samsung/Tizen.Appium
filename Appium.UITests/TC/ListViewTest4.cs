using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewTest4
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewTest4(string platform)
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
            var btnId = "setButton";

            WebElementUtils.Click(Driver, btnId);

            // screenshot
        }

        [Test]
        public void SelectGroupTest()
        {
            var btnId = "setButton2";

            WebElementUtils.Click(Driver, btnId);
            // screenshot
        }

        [Test]
        public void SelectGroupItemTest()
        {
            var btnId = "setButton3";

            WebElementUtils.Click(Driver, btnId);

            // screenshot
        }
    }
}

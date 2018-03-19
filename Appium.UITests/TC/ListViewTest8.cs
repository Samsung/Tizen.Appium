using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewTest8
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewTest8(string platform)
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
        public void AddRemoveTest()
        {
            var btnId = "button";

            WebElementUtils.Click(Driver, btnId);
            //screenshot

            WebElementUtils.Click(Driver, btnId);
            //screenshot
        }
    }
}

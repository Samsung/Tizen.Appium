using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewTest10
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewTest10(string platform)
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
        public void HeightTest()
        {
            var listId = "listView";
            var itemString = "Height 100";
            var itemString2 = "Height 400";

            // viewcell is not supported

            //screenshot
        }
    }
}

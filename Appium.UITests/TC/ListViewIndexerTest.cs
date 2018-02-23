using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewIndexerTest
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewIndexerTest(string platform)
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
        public void Enable1Test()
        {
            var btnId = "enable1";
            WebElementUtils.Click(Driver, btnId);

            //screenshot for checking index on the listview
        }

        [Test]
        public void Enable2Test()
        {
            var btnId = "enable2";
            WebElementUtils.Click(Driver, btnId);

            //screenshot for checking index on the listview
        }

        [Test]
        public void Enable3Test()
        {
            var btnId = "enable3";
            WebElementUtils.Click(Driver, btnId);

            //screenshot for checking index on the listview
        }
    }
}

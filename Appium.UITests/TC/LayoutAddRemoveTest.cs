using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class LayoutAddRemoveTest
    {
        string PlatformName;
        AppiumDriver Driver;

        public LayoutAddRemoveTest(string platform)
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
            var addBtnId = "addbtn";

            WebElementUtils.Click(Driver, addBtnId);

            // screenshot
        }

        [Test]
        public void AddRemoveTest()
        {
            var addBtnId = "addbtn";
            var removeBtnId = "removebtn";

            WebElementUtils.Click(Driver, addBtnId);
            WebElementUtils.Click(Driver, removeBtnId);

            //screenshot
        }
    }
}

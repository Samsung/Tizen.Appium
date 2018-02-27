using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class TabbedPageTest4
    {
        string PlatformName;
        AppiumDriver Driver;

        public TabbedPageTest4(string platform)
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
        public void InsertBeforeTest()
        {
            var insertBeforeBtnId = "insertBeforeButton_1";
            var insertAfterBtnId = "insertAfterButton_1";
            var removeBtnId = "removeButton_1";

            WebElementUtils.Click(Driver, insertBeforeBtnId);
            //screenshot

            WebElementUtils.Click(Driver, insertAfterBtnId);
            //screenshot

            WebElementUtils.Click(Driver, removeBtnId);
            //screenshot
        }
    }
}

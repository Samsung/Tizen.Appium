using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class TableViewTest6
    {
        string PlatformName;
        AppiumDriver Driver;

        public TableViewTest6(string platform)
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
        public void ViewTest()
        {
            var redBtnId = "red";
            var greenBtnId = "green";
            var grayBtnId = "gray";

            WebElementUtils.Click(Driver, redBtnId);
            //screenshot

            WebElementUtils.Click(Driver, greenBtnId);
            //screenshot

            WebElementUtils.Click(Driver, grayBtnId);
            //screenshot
        }
    }
}

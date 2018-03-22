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

            WebElementUtils.Click(Driver, insertBeforeBtnId);

            var image = "TabbedPageTest4_insertBeforeButton_1.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void InsertBeforeTest2()
        {
            var insertAfterBtnId = "insertAfterButton_1";

            WebElementUtils.Click(Driver, insertAfterBtnId);

            var image = "TabbedPageTest4_insertAfterButton_1.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void InsertBeforeTest3()
        {
            var removeBtnId = "removeButton_1";

            WebElementUtils.Click(Driver, removeBtnId);

            var image = "TabbedPageTest4_removeButton_1.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }
    }
}

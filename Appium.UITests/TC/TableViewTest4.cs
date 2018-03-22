using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class TableViewTest4
    {
        string PlatformName;
        AppiumDriver Driver;

        public TableViewTest4(string platform)
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
            var tableViewId = "table";
            var checkId = "check";
            var set0BtnId = "btnSet0";
            var setMinus1BtnId = "btnSet_minus1";
            var sliderId = "slider";

            var hasUnevenCell = WebElementUtils.GetAttribute<bool>(Driver, tableViewId, "HasUnevenRows");
            if (!hasUnevenCell)
            {
                WebElementUtils.Click(Driver, checkId);
            }

            WebElementUtils.Click(Driver, set0BtnId);

            WebElementUtils.SetAttribute(Driver, sliderId, "Value", 100);

            WebElementUtils.Click(Driver, setMinus1BtnId);

            var image = "TabelViewTest4.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, imageName);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }
    }
}

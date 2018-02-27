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

            var hasUnevenCell = WebElementUtils.GetAttribute(Driver, tableViewId, "HasUnevenRows");
            if (!Convert.ToBoolean(hasUnevenCell))
            {
                WebElementUtils.Click(Driver, checkId);
            }

            WebElementUtils.Click(Driver, set0BtnId);
            //screenshot

            //set slider value 100

            WebElementUtils.Click(Driver, setMinus1BtnId);
            //screenshot
        }
    }
}

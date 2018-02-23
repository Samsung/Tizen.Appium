using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class MasterDetailedTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public MasterDetailedTest1(string platform)
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
            var pageId = "MasterDetailPage";
            var touchScreen = new RemoteTouchScreenUtils(Driver);

            var isPresented = WebElementUtils.GetAttribute(Driver, pageId, "IsPresented");

            if (!Convert.ToBoolean(isPresented))
            {
                touchScreen.Drag(0, 500, 300, 500);
            }

            isPresented = WebElementUtils.GetAttribute(Driver, pageId, "IsPresented");
            Assert.True(Convert.ToBoolean(isPresented), "IsPresented should be true, but got " + isPresented);

            //screenshot
        }
    }
}

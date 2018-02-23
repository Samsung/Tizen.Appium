using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class MasterDetailedTest3
    {
        string PlatformName;
        AppiumDriver Driver;

        public MasterDetailedTest3(string platform)
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
        public void ToggleTest()
        {
            var pageId = "MasterDetailPage";
            var touchScreen = new RemoteTouchScreenUtils(Driver);
            var masterBtnId = "master_button1";
            var togglBtnId = "detail_button1";

            var isPresented = WebElementUtils.GetAttribute(Driver, pageId, "IsPresented");

            if (Convert.ToBoolean(isPresented))
            {
                WebElementUtils.Click(Driver, masterBtnId);
            }

            isPresented = WebElementUtils.GetAttribute(Driver, pageId, "IsPresented");
            Assert.False(Convert.ToBoolean(isPresented), "IsPresented should not be false, but got " + isPresented);

            WebElementUtils.Click(Driver, togglBtnId);

            isPresented = WebElementUtils.GetAttribute(Driver, pageId, "IsPresented");
            Assert.True(Convert.ToBoolean(isPresented), "IsPresented should not be true, but got " + isPresented);

            //screenshot
        }

        [Test]
        public void ChangeTest()
        {
            var pageId = "MasterDetailPage";
            var touchScreen = new RemoteTouchScreenUtils(Driver);
            var togglBtnId = "detail_button1";
            var masterBtnId = "master_button1";
            var changeBtnId = "detail_button2";

            var isPresented = WebElementUtils.GetAttribute(Driver, pageId, "IsPresented");

            if (Convert.ToBoolean(isPresented))
            {
                WebElementUtils.Click(Driver, masterBtnId);
            }

            isPresented = WebElementUtils.GetAttribute(Driver, pageId, "IsPresented");
            Assert.False(Convert.ToBoolean(isPresented), "IsPresented should not be false, but got " + isPresented);

            WebElementUtils.Click(Driver, changeBtnId);
            WebElementUtils.Click(Driver, togglBtnId);

            isPresented = WebElementUtils.GetAttribute(Driver, pageId, "IsPresented");
            Assert.True(Convert.ToBoolean(isPresented), "IsPresented should not be true, but got " + isPresented);

            //screenshot
        }

        [Test]
        public void RestoreTest()
        {
            var pageId = "MasterDetailPage";
            var touchScreen = new RemoteTouchScreenUtils(Driver);
            var masterBtnId = "master_button1";
            var togglBtnId = "detail_button1";
            var restoreBtnId = "detail_button3";

            var isPresented = WebElementUtils.GetAttribute(Driver, pageId, "IsPresented");
            if (Convert.ToBoolean(isPresented))
            {
                WebElementUtils.Click(Driver, masterBtnId);
            }

            isPresented = WebElementUtils.GetAttribute(Driver, pageId, "IsPresented");
            Assert.False(Convert.ToBoolean(isPresented), "IsPresented should not be false, but got " + isPresented);

            WebElementUtils.Click(Driver, restoreBtnId);
            WebElementUtils.Click(Driver, togglBtnId);

            isPresented = WebElementUtils.GetAttribute(Driver, pageId, "IsPresented");
            Assert.True(Convert.ToBoolean(isPresented), "IsPresented should not be true, but got " + isPresented);

            //screenshot
        }
    }
}

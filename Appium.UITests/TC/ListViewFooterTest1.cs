using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewFooterTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewFooterTest1(string platform)
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
        public void FooterTest()
        {
            // issue

            //var itemId = "20th list item";

            //var remoteTouch = new RemoteTouchScreenUtils(Driver);
            //var isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");

            //while (!isEnabled)
            //{
            //    remoteTouch.Flick(0, -10);
            //    isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            //}

            //WebElementUtils.Click(Driver, itemId);
            //remoteTouch.Flick(0, -3);

            //isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            //Assert.True(isEnabled, itemId + ".isEnabled should be true, but got " + isEnabled);
        }
    }
}

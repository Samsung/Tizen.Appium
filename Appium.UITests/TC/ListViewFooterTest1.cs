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
            var listId = "list";
            var itemString = "20th list item";

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            var touchScreen = new RemoteTouchScreenUtils(Driver);
            while (itemId == string.Empty)
            {
                touchScreen.Flick(0, -3);
                itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            }

            WebElementUtils.Click(Driver, itemId);
            touchScreen.Flick(0, -3);

            //screenshot for checking footer of the listview
        }
    }
}

using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewHeaderTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewHeaderTest1(string platform)
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

        //[Test]
        public void HeaderTest()
        {
            // issue

            //var listId = "list";
            ////var itemString = "list item #1";
            //var itemString = "list item 1";

            //Console.WriteLine("itemString: " + itemString);
            //var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            //Assert.False(String.IsNullOrEmpty(itemId), itemId + "should not be empty or null, but got " + itemId);

            //WebElementUtils.Click(Driver, itemId);

            //screenshot for checking header of the listview
        }
    }
}

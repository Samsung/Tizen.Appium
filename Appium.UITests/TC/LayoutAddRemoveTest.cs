using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class LayoutAddRemoveTest
    {
        string PlatformName;
        AppiumDriver Driver;

        public LayoutAddRemoveTest(string platform)
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
        public void AddTest()
        {
            var btnId = "addbtn";
            var elementId = "addedBox";

            WebElementUtils.Click(Driver, btnId);

            var isVisible = WebElementUtils.GetAttribute(Driver, elementId, "IsVisible");
            Assert.True(Convert.ToBoolean(isVisible), elementId + ".IsVisible should be true, but got " + isVisible);
        }

        [Test]
        public void RemoveTest()
        {
            var btnId = "removebtn";
            var elementId = "addedBox";

            var isVisible = WebElementUtils.GetAttribute(Driver, elementId, "IsVisible");
            Assert.True(Convert.ToBoolean(isVisible), elementId + ".IsVisible should be true, but got " + isVisible);

            WebElementUtils.Click(Driver, btnId);

            Assert.False(Convert.ToBoolean(isVisible), elementId + ".IsVisible should be false, but got " + isVisible);
        }
    }
}

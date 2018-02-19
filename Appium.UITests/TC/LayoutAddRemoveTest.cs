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
            WebElementUtils.Click(Driver, "addbtn");

            var elementId = "addedBox";
            var x = WebElementUtils.GetAttribute(Driver, elementId, "X");
            var y = WebElementUtils.GetAttribute(Driver, elementId, "Y");
            var width = WebElementUtils.GetAttribute(Driver, elementId, "Width");
            var height = WebElementUtils.GetAttribute(Driver, elementId, "Height");
            var isVisible = WebElementUtils.GetAttribute(Driver, elementId, "IsVisible");

            Assert.True((Convert.ToDouble(x) >= 0), "Failed x: " + x);
            Assert.True((Convert.ToDouble(y) >= 0), "Failed y: " + y);
            Assert.True((Convert.ToDouble(width) >= 0), "Failed width: " + width);
            Assert.True((Convert.ToDouble(height) >= 0), "Failed height: " + height);
            Assert.True(Convert.ToBoolean(isVisible), "Failed IsVisible: " + isVisible);
        }

        [Test]
        public void RemoveTest()
        {
            WebElementUtils.Click(Driver, "removebtn");

            var elementId = "addedBox";
            var isVisible = WebElementUtils.GetAttribute(Driver, elementId, "IsVisible");
            Assert.False(Convert.ToBoolean(isVisible), "Failed IsVisible: " + isVisible);
        }
    }
}

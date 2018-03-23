using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class SetColorTest
    {
        string PlatformName;
        AppiumDriver Driver;

        public SetColorTest(string platform)
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
        public void ChangeColorTest()
        {
            var btnId = "button";
            string currentButton = WebElementUtils.GetAttribute(Driver, "button", "TextColor");
            string currentai = WebElementUtils.GetAttribute(Driver, "ai", "Color");
            string currentbv = WebElementUtils.GetAttribute(Driver, "bv", "Color");
            string currentst = WebElementUtils.GetAttribute(Driver, "st", "Color");

            WebElementUtils.Click(Driver, btnId);

            string changedButton = WebElementUtils.GetAttribute(Driver, "button", "TextColor");
            string changedai = WebElementUtils.GetAttribute(Driver, "ai", "Color");
            string changedbv = WebElementUtils.GetAttribute(Driver, "bv", "Color");
            string changedst = WebElementUtils.GetAttribute(Driver, "st", "Color");

            Assert.AreNotEqual(currentButton, changedButton);
            Assert.AreNotEqual(currentai, changedai);
            Assert.AreNotEqual(currentbv, changedbv);
            Assert.AreNotEqual(currentst, changedst);
        }
    }
}

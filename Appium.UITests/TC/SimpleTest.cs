using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class SimpleTest
    {
        string PlatformName;
        AppiumDriver Driver;

        public SimpleTest(string platform)
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
            var btnId = "button";
            var labelId = "label";
            var expected = "click count: 1";

            WebElementUtils.Click(Driver, btnId);

            var text = WebElementUtils.GetAttribute<string>(Driver, labelId, "Text");

            Assert.True((text == expected), "expected: " + expected + ", but got " + text);
        }
    }
}

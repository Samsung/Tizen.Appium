using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class RotationTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public RotationTest1(string platform)
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
        public void RotationTest()
        {
            var elementId = "btn";
            var before = WebElementUtils.GetAttribute(Driver, elementId, "Rotation");
            WebElementUtils.Click(Driver, elementId);
            var after = WebElementUtils.GetAttribute(Driver, elementId, "Rotation");

            Assert.AreNotEqual(before, after, before + " should be changed to " + after);
        }
    }
}

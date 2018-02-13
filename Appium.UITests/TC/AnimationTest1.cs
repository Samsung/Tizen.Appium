using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class AnimationTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public AnimationTest1(string platform)
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
        public void ClickTest()
        {
            Point point = WebElementUtils.GetLocation(Driver, "imgTest");
            WebElementUtils.Click(Driver, "btnStartAnim");
            Point point2 = WebElementUtils.GetLocation(Driver, "imgTest");
            Assert.AreNotEqual(point, point2);
        }
    }
}

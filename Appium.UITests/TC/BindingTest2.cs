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
    public class BindingTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public BindingTest2(string platform)
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
        public void BindingTest()
        {
            var box1Id = "box1";
            var box2Id = "box2";
            var sliderId = "slider";
            var value = 150;

            WebElementUtils.SetAttribute(Driver, sliderId, "Value", value);

            var width1 = WebElementUtils.GetAttribute<double>(Driver, box1Id, "Width");
            var width2 = WebElementUtils.GetAttribute<double>(Driver, box2Id, "Width");

            Assert.True((width1 == value), "Height should be same with " + value);
            Assert.True((width2 == value), "Width should be same with " + value);
        }
    }
}

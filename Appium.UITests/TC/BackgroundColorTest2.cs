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
    public class BackgroundColorTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public BackgroundColorTest2(string platform)
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
        public void StackLayoutBackgroundTest()
        {
            string result = WebElementUtils.GetAttribute(Driver, "layout1", "BackgroundColor");
            WebElementUtils.Click(Driver, "button1");
            string result2 = WebElementUtils.GetAttribute(Driver, "layout1", "BackgroundColor");
            //Assert.AreNotEqual(result, result2);
        }

        [Test]
        public void StackLayoutBackgroundTest2()
        {
            string result = WebElementUtils.GetAttribute(Driver, "layout2", "BackgroundColor");
            WebElementUtils.Click(Driver, "button2");
            string result2 = WebElementUtils.GetAttribute(Driver, "layout2", "BackgroundColor");
            //Assert.AreNotEqual(result, result2);
        }
    }
}

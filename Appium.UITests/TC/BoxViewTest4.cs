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
    public class BoxViewTest4
    {
        string PlatformName;
        AppiumDriver Driver;

        public BoxViewTest4(string platform)
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
        public void ScaleTest1()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "box", "Scale");
            WebElementUtils.Click(Driver, "button");
            WebElementUtils.Click(Driver, "button");
            string ret2 = WebElementUtils.GetAttribute(Driver, "box", "Scale");
        }

        [Test]
        public void ScaleTest2()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "box", "Scale");
            WebElementUtils.Click(Driver, "button2");
            WebElementUtils.Click(Driver, "button2");
            string ret2 = WebElementUtils.GetAttribute(Driver, "box", "Scale");
        }
    }
}

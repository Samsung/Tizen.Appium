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
    public class BindingTest3
    {
        string PlatformName;
        AppiumDriver Driver;

        public BindingTest3(string platform)
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
            string ret = WebElementUtils.GetAttribute(Driver, "buttony", "Text");
            WebElementUtils.Click(Driver, "buttony");
            string ret2 = WebElementUtils.GetAttribute(Driver, "buttony", "Text");
            Assert.AreNotEqual(ret, ret2);
        }

        [Test]
        public void BindingTest2()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "buttonx", "Text");
            WebElementUtils.Click(Driver, "buttonx");
            string ret2 = WebElementUtils.GetAttribute(Driver, "buttonx", "Text");
            Assert.AreNotEqual(ret, ret2);
        }
    }
}

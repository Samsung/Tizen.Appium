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
            var touch = new RemoteTouchScreenUtils(Driver);
            string box1width = WebElementUtils.GetAttribute(Driver, "box1", "WidthRequest");
            string box2width = WebElementUtils.GetAttribute(Driver, "box2", "WidthRequest");
            touch.Down(450, 599);
            touch.Up(450, 599);
            string box1width2 = WebElementUtils.GetAttribute(Driver, "box1", "WidthRequest");
            string box2width2 = WebElementUtils.GetAttribute(Driver, "box2", "WidthRequest");
            Assert.AreNotEqual(box1width, box1width2);
            Assert.AreNotEqual(box2width, box2width2);
        }
    }
}

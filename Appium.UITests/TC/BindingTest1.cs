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
    public class BindingTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public BindingTest1(string platform)
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
            string box1Ret = WebElementUtils.GetAttribute(Driver, "box1", "IsVisible");
            string box2Ret = WebElementUtils.GetAttribute(Driver, "box2", "IsVisible");
            WebElementUtils.Click(Driver, "btn");
            string box1Ret2 = WebElementUtils.GetAttribute(Driver, "box1", "IsVisible");
            string box2Ret2 = WebElementUtils.GetAttribute(Driver, "box2", "IsVisible");
            Assert.AreNotEqual(box1Ret, box1Ret2);
            Assert.AreNotEqual(box2Ret, box2Ret2);
        }
    }
}

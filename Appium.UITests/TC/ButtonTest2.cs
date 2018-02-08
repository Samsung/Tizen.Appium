using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions.Internal;

namespace Appium.UITests
{
    //[TestFixture("Android")]
    [TestFixture("Tizen")]
    public class ButtonTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public ButtonTest2(string platform)
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
            string before = WebElementUtils.GetAttribute(Driver, "btnColored", "TextColor");
            WebElementUtils.Click(Driver, "btnColored");
            string after = WebElementUtils.GetAttribute(Driver, "btnColored", "TextColor");
            Assert.AreNotEqual(before, after);
        }

        [Test]
        public void ClickTest2()
        {
            string before = WebElementUtils.GetAttribute(Driver, "btnDisableTarget", "IsEnabled");
            Assert.AreEqual("False", before);

            WebElementUtils.Click(Driver, "btnDisableToggle");

            string after = WebElementUtils.GetAttribute(Driver, "btnDisableTarget", "IsEnabled");
            Assert.AreEqual("True", after);
        }
    }
}

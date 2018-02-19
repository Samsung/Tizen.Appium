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
    public class BindingTest4
    {
        string PlatformName;
        AppiumDriver Driver;

        public BindingTest4(string platform)
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
        public void LabelBindingTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "lb", "TextColor");
            WebElementUtils.Click(Driver, "btn1");
            string ret2 = WebElementUtils.GetAttribute(Driver, "lb", "TextColor");
            Assert.AreNotEqual(ret, ret2);
        }

        [Test]
        public void ButtonBindingTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "btn1", "TextColor");
            WebElementUtils.Click(Driver, "btn1");
            string ret2 = WebElementUtils.GetAttribute(Driver, "btn1", "TextColor");
            Assert.AreNotEqual(ret, ret2);
        }

        [Test]
        public void EditorBindingTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "editor", "TextColor");
            WebElementUtils.Click(Driver, "btn1");
            string ret2 = WebElementUtils.GetAttribute(Driver, "editor", "TextColor");
            Assert.AreNotEqual(ret, ret2);
        }
    }
}

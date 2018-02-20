using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions.Internal;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class KeyboardTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public KeyboardTest1(string platform)
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
        public void ChatKeyboardTest()
        {
            WebElementUtils.Click(Driver, "btnDefault");
            WebElementUtils.Click(Driver, "btnKeyBorChat");
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(326, 283);
            touch.Up(326, 283);
        }

        [Test]
        public void DefaultKeyboardTest()
        {
            WebElementUtils.Click(Driver, "btnDefault");
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(326, 283);
            touch.Up(326, 283);
        }

        [Test]
        public void EmailKeyboardTest()
        {
            WebElementUtils.Click(Driver, "btnDefault");
            WebElementUtils.Click(Driver, "btnEmail");
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(326, 283);
            touch.Up(326, 283);
        }

        [Test]
        public void NumericKeyboardTest()
        {
            WebElementUtils.Click(Driver, "btnDefault");
            WebElementUtils.Click(Driver, "btnNumeric");
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(326, 283);
            touch.Up(326, 283);
        }

        [Test]
        public void PlainKeyboardTest()
        {
            WebElementUtils.Click(Driver, "btnDefault");
            WebElementUtils.Click(Driver, "btnPlain");
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(326, 283);
            touch.Up(326, 283);
        }

        [Test]
        public void TelephoneKeyboardTest()
        {
            WebElementUtils.Click(Driver, "btnDefault");
            WebElementUtils.Click(Driver, "btnTelephone");
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(326, 283);
            touch.Up(326, 283);
        }

        [Test]
        public void TextKeyboardTest()
        {
            WebElementUtils.Click(Driver, "btnDefault");
            WebElementUtils.Click(Driver, "btnText");
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(326, 283);
            touch.Up(326, 283);
        }

        [Test]
        public void UrlKeyboardTest()
        {
            WebElementUtils.Click(Driver, "btnDefault");
            WebElementUtils.Click(Driver, "btnUrl");
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(326, 283);
            touch.Up(326, 283);
        }
    }
}

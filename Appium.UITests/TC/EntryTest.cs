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
    [TestFixture("Tizen")]
    public class EntryTest
    {
        string PlatformName;
        AppiumDriver Driver;

        public EntryTest(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);
            var touchScreen = new RemoteTouchScreenUtils(Driver);
            touchScreen.Flick(0, -11);

            string testId = WebElementUtils.GetAttribute(Driver, "Content", this.GetType().Name);
            WebElementUtils.Click(Driver, testId);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void SetTextTest()
        {
            string before = WebElementUtils.GetText(Driver, "emptyEntry");
            string addString = "ABCDEFG";
            WebElementUtils.SetText(Driver, "emptyEntry", addString);

            var touchScreen = new RemoteTouchScreen(Driver.Driver);
            touchScreen.Down(240, 187);
            touchScreen.Up(240, 187);

            string after = WebElementUtils.GetText(Driver, "emptyEntry");

            Assert.AreEqual(before+addString, after);
        }

        [Test]
        public void SetTextTest2()
        {
            string before = WebElementUtils.GetText(Driver, "passwdEntry");
            string addString = "ABCDEFG";
            WebElementUtils.SetText(Driver, "passwdEntry", addString);

            var touchScreen = new RemoteTouchScreen(Driver.Driver);
            touchScreen.Down(240, 187);
            touchScreen.Up(240, 187);

            string after = WebElementUtils.GetText(Driver, "passwdEntry");

            Assert.AreEqual(before + addString, after);
        }

        [Test]
        public void GetTextTest()
        {
            string result = WebElementUtils.GetText(Driver, "longEntry");
            Assert.AreEqual("This is a Entry with very looooooooooooong looooooooooooooong text", result);
        }
    }
}

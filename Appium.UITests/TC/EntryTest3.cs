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
    public class EntryTest3
    {
        string PlatformName;
        AppiumDriver Driver;

        public EntryTest3(string platform)
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
        public void TextChangedTest()
        {
            string add = "ABCDEFG";
            WebElementUtils.SetText(Driver, "entry2", add);

            var touchScreen = new RemoteTouchScreenUtils(Driver);
            touchScreen.Down(240, 187);
            touchScreen.Up(240, 187);

            string result = WebElementUtils.GetText(Driver, "entry");
            Assert.AreEqual("Text changed", result);
        }

        [Test]
        public void TextColorTest()
        {
            WebElementUtils.Click(Driver, "bt");
            string result = WebElementUtils.GetAttribute(Driver, "entry2", "TextColor");
            Assert.AreEqual("[Color: A=1, R=0, G=0.501960813999176, B=0, Hue=0.333333343267441, Saturation=1, Luminosity=0.250980406999588]", result);
        }
    }
}

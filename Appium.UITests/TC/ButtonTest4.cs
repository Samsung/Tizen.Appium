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
    public class ButonTest4
    {
        string PlatformName;
        AppiumDriver Driver;

        public ButonTest4(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);

            var touchScreen = new RemoteTouchScreenUtils(Driver);
            touchScreen.Flick(0, -8);

            string testId = WebElementUtils.GetAttribute(Driver, "Content", this.GetType().Name);
            WebElementUtils.Click(Driver, testId);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void ClickTest()
        {
            WebElementUtils.Click(Driver, "button1");
            WebElementUtils.Click(Driver, "button2");
            var touchScreen = new RemoteTouchScreenUtils(Driver);
            touchScreen.Flick(0, -3);
            WebElementUtils.Click(Driver, "button3");
            WebElementUtils.Click(Driver, "button4");
            touchScreen.Flick(0, -7);
        }
    }
}

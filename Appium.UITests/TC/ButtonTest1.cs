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
    public class ButtonTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public ButtonTest1(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);

            var touchScreen = new RemoteTouchScreenUtils(Driver);
            touchScreen.Flick(0, -7);

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
            WebElementUtils.Click(Driver, "btnColored");
        }

        [Test]
        public void ClickTest2()
        {
            WebElementUtils.Click(Driver, "btnTxtToggle");
            string result = WebElementUtils.GetText(Driver, "btnTxtToggle");
            Assert.AreEqual(result, string.Empty);
        }

        [Test]
        public void ClickTest3()
        { 
            WebElementUtils.Click(Driver, "btnImgToggle");
            string result = WebElementUtils.GetAttribute(Driver, "btnImgToggle", "Image");
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void ClickTest4()
        {
            WebElementUtils.Click(Driver, "btnDisableToggle");
            string result = WebElementUtils.GetAttribute(Driver, "btnDisableTarget", "IsEnabled");
            Assert.AreEqual("True", result);

            WebElementUtils.Click(Driver, "btnDisableTarget");
        }
    }
}

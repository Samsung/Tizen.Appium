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
    public class EditorTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public EditorTest1(string platform)
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
        public void GetTextTest()
        {
            string result = WebElementUtils.GetText(Driver, "editor");
            Assert.AreEqual("Plase, input any sentence.", result);
        }

        void GetTextTest2()
        {
            string origin = "This test is for testing Editor with very long text. This software is the confidential and proprietary information of Samsung Electronics, Inc. You shall not disclose such Confidential Information and shall use it only in accordance with the terms of the license agreement you entered into with Samsung.";
            string result = WebElementUtils.GetText(Driver, "internalEditor");
            Assert.AreEqual(origin, result);
        }
    }
}

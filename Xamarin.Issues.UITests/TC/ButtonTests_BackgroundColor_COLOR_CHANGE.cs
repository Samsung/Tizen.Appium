using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class ActivityIndicatorTest_ActivityIndicator_Rotation_UILK
    {
        string PlatformName;
        AppiumDriver Driver;

        public ActivityIndicatorTest_ActivityIndicator_Rotation_UILK(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);
            TestScriptUtils.FindTC(Driver, this.GetType().Name);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void Rotation50Test()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "_mActivityIndicator", "Rotation");

            Point listPt = new Point(561, 584);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(listPt.X, listPt.Y );
            touch.Up(listPt.X, listPt.Y);

            string ret2 = WebElementUtils.GetAttribute(Driver, "_mActivityIndicator", "Rotation");
            Assert.AreNotEqual(ret, ret2);
        }

        [Test]
        public void Rotation90Test()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "_mActivityIndicator", "Rotation");

            Point listPt = new Point(449, 831);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(listPt.X, listPt.Y);
            touch.Up(listPt.X, listPt.Y);

            string ret2 = WebElementUtils.GetAttribute(Driver, "_mActivityIndicator", "Rotation");
            Assert.AreNotEqual(ret, ret2);
        }

        [Test]
        public void Rotation180Test()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "_mActivityIndicator", "Rotation");

            Point listPt = new Point(413, 1051);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(listPt.X, listPt.Y);
            touch.Up(listPt.X, listPt.Y);

            string ret2 = WebElementUtils.GetAttribute(Driver, "_mActivityIndicator", "Rotation");
            Assert.AreNotEqual(ret, ret2);
        }

    }
}

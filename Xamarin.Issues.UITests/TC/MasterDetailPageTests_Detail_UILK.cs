using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class MasterDetailPageTests_Detail_UILK
    {
        string PlatformName;
        AppiumDriver Driver;

        public MasterDetailPageTests_Detail_UILK(string platform)
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
        public void DetailTest()
        {
            string ret = WebElementUtils.GetText(Driver, "_detail");

            Point pt = new Point(355, 424);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(pt.X, pt.Y);
            touch.Up(pt.X, pt.Y);

            string ret2 = WebElementUtils.GetText(Driver, "_detail");

            Assert.AreNotEqual(ret, ret2);
        }

        [Test]
        public void DetailTest2()
        {
            string ret = WebElementUtils.GetText(Driver, "_detail");

            Point pt = new Point(390, 710);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(pt.X, pt.Y);
            touch.Up(pt.X, pt.Y);

            string ret2 = WebElementUtils.GetText(Driver, "_detail");

            Assert.AreNotEqual(ret, ret2);
        }
    }
}

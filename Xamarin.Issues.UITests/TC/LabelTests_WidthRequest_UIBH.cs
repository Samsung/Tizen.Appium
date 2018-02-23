using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class LabelTests_WidthRequest_UIBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public LabelTests_WidthRequest_UIBH(string platform)
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
        public void WidthRequestTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "_labelOne", "Height");
            Double h = Convert.ToDouble(ret);

            Point pt = new Point(559, 620);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(pt.X, pt.Y);
            touch.Up(pt.X, pt.Y);

            string ret2 = WebElementUtils.GetAttribute(Driver, "_labelOne", "Height");
            Double h2 = Convert.ToDouble(ret2);

            Assert.Greater(h, h2);
        }
    }
}

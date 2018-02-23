using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class GridTests_RowSpacing_UIBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public GridTests_RowSpacing_UIBH(string platform)
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
        public void RowSpacingTest()
        {
            Size box1 = WebElementUtils.GetSize(Driver, "BoxView1");

            Point pt = new Point(548, 1260);
            var touch = new RemoteTouchScreenUtils(Driver);

            touch.Down(pt.X, pt.Y);
            touch.Up(pt.X, pt.Y);

            touch.Down(pt.X/2, pt.Y);
            touch.Up(pt.X/2, pt.Y);

            touch.Down(pt.X, pt.Y);
            touch.Up(pt.X, pt.Y);

            Size box2 = WebElementUtils.GetSize(Driver, "BoxView1");
            Assert.Greater(box1.Height, box2.Height);
        }
    }
}

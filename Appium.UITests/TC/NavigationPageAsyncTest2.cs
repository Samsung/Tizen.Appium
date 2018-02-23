using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class NavigationPageAsyncTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public NavigationPageAsyncTest2(string platform)
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
        public void InsertTest()
        {
            var pushBtnId = "pushBtn_1";
            var insertBtnId = "insertBefore_2";

            var depthBefore = GetNavigationStackDepth();

            WebElementUtils.Click(Driver, pushBtnId);

            var depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore < depthAfter), "StackDepth should be increased, but got before: " + depthBefore + ", after: " + depthAfter);

            depthBefore = depthAfter;
            var currenPageBefore = GetNavigationCurrenPage();

            WebElementUtils.Click(Driver, insertBtnId);

            var currenPageAfter = GetNavigationCurrenPage();
            depthAfter = GetNavigationStackDepth();
            Assert.True((depthBefore < depthAfter), "StackDepth should be increased, but got before: " + depthBefore + ", after: " + depthAfter);
            Assert.True((currenPageBefore == currenPageAfter), "CurrenPage should be same, but got before: " + depthBefore + ", after: " + depthAfter);

            //screenshot
            Driver.Driver.Navigate().Back();
            //screenshot
            Driver.Driver.Navigate().Back();
            //screenshot

            System.Threading.Thread.Sleep(3000);
        }

        [Test]
        public void RemoveTopTest()
        {
            var pushBtnId = "pushBtn_1";
            var removeBtnId = "removeTop_2";

            var depthBefore = GetNavigationStackDepth();
            var currentPageBefore = GetNavigationCurrenPage();

            WebElementUtils.Click(Driver, pushBtnId);

            var depthAfter = GetNavigationStackDepth();
            var currentPageAfter = GetNavigationCurrenPage();
            Assert.True((depthBefore < depthAfter), "StackDepth should be increased, but got before: " + depthBefore + ", after: " + depthAfter);
            Assert.True((currentPageBefore != currentPageAfter), "current page should not be same, but got before: " + depthBefore + ", after: " + depthAfter);
            //screenshot

            WebElementUtils.Click(Driver, removeBtnId);

            depthAfter = GetNavigationStackDepth();
            currentPageAfter = GetNavigationCurrenPage();
            Assert.True((depthBefore == depthAfter), "StackDepth should be same, but got before: " + depthBefore + ", after: " + depthAfter);
            Assert.True((currentPageBefore == currentPageAfter), "current page should be same, but got before: " + depthBefore + ", after: " + depthAfter);
            //screenshot
        }

        [Test]
        public void RemoveBeforeTest()
        {
            var pushBtnId = "pushBtn_1";
            var pushBtn2Id = "pushBtn_2";
            var removeBtnId = "removeBeforeTop_3";

            var depthBefore = GetNavigationStackDepth();
            var currentPageBefore = GetNavigationCurrenPage();

            Console.WriteLine("#### depthBefore: " + depthBefore);

            WebElementUtils.Click(Driver, pushBtnId);
            WebElementUtils.Click(Driver, pushBtn2Id);

            var depthAfter = GetNavigationStackDepth();
            var currentPageAfter = GetNavigationCurrenPage();

            Console.WriteLine("#### depthBefore: " + depthBefore);
            Console.WriteLine("#### depthAfter: " + depthAfter);
            Assert.True(((depthBefore + 2) == depthAfter), "StackDepth should be increased, but got before: " + depthBefore + ", after: " + depthAfter);
            Assert.True((currentPageBefore != currentPageAfter), "current page should not be same, but got before: " + depthBefore + ", after: " + depthAfter);
            //screenshot

            depthBefore = depthAfter;
            currentPageBefore = currentPageAfter;

            WebElementUtils.Click(Driver, removeBtnId);

            depthAfter = GetNavigationStackDepth();
            currentPageAfter = GetNavigationCurrenPage();
            Assert.True((depthBefore > depthAfter), "StackDepth should be decreased, but got before: " + depthBefore + ", after: " + depthAfter);
            Assert.True((currentPageBefore == currentPageAfter), "current page should be same, but got before: " + depthBefore + ", after: " + depthAfter);
            //screenshot

            Driver.Driver.Navigate().Back();
            System.Threading.Thread.Sleep(3000);
            //screenshot
        }

        int GetNavigationStackDepth()
        {
            var depth = WebElementUtils.GetAttribute(Driver, "MainPage", "StackDepth");
            return Convert.ToInt32(depth);
        }

        string GetNavigationCurrenPage()
        {
            var page = WebElementUtils.GetAttribute(Driver, "MainPage", "CurrentPage");
            return page;
        }
    }
}

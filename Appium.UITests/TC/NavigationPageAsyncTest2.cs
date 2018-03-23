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

            var image = "NavigationPageAsyncTest2_insert.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
            Driver.Driver.Navigate().Back();

            var image2 = "NavigationPageAsyncTest2_insert2.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image2);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image2));
            Driver.Driver.Navigate().Back();

            var image3 = "NavigationPageAsyncTest2_insert3.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image3);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image3));

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

            var image = "NavigationPageAsyncTest2_removeTop.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));

            WebElementUtils.Click(Driver, removeBtnId);

            depthAfter = GetNavigationStackDepth();
            currentPageAfter = GetNavigationCurrenPage();
            Assert.True((depthBefore == depthAfter), "StackDepth should be same, but got before: " + depthBefore + ", after: " + depthAfter);
            Assert.True((currentPageBefore == currentPageAfter), "current page should be same, but got before: " + depthBefore + ", after: " + depthAfter);

            var image2 = "NavigationPageAsyncTest2_removeTop2.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image2);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image2));
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

            var image = "NavigationPageAsyncTest2_removeBefore.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));

            depthBefore = depthAfter;
            currentPageBefore = currentPageAfter;

            WebElementUtils.Click(Driver, removeBtnId);

            depthAfter = GetNavigationStackDepth();
            currentPageAfter = GetNavigationCurrenPage();
            Assert.True((depthBefore > depthAfter), "StackDepth should be decreased, but got before: " + depthBefore + ", after: " + depthAfter);
            Assert.True((currentPageBefore == currentPageAfter), "current page should be same, but got before: " + depthBefore + ", after: " + depthAfter);

            var image2 = "NavigationPageAsyncTest2_removeBefore2.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image2);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image2));

            Driver.Driver.Navigate().Back();
            System.Threading.Thread.Sleep(3000);

            var image3 = "NavigationPageAsyncTest2_removeBefore3.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image3);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image3));
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

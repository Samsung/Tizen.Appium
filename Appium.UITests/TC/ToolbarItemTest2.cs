using OpenQA.Selenium.Remote;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ToolbarItemTest2
    {
        string PlatformName;
        AppiumDriver Driver;
        RemoteTouchScreen touch;
        int leftToolbarItemX = 100;
        int rightToolbarItemX = 660;
        int toolbarItemY = 90;

        public ToolbarItemTest2(string platform)
        {
            PlatformName = platform;
        }

        void ClickLeftToolbarItem()
        {
            touch.Down(leftToolbarItemX, toolbarItemY);
            touch.Up(leftToolbarItemX, toolbarItemY);
            System.Threading.Thread.Sleep(3000);
        }

        void ClickRightToolbarItem()
        {
            touch.Down(rightToolbarItemX, toolbarItemY);
            touch.Up(rightToolbarItemX, toolbarItemY);
            System.Threading.Thread.Sleep(3000);
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);
            FormsTizenGalleryUtils.FindTC(Driver, this.GetType().Name);

            touch = new RemoteTouchScreen(Driver.Driver);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void TestMultiPageToolbar()
        {
            bool result = false;
            WebElementUtils.Click(Driver, "button1");
            string title = WebElementUtils.GetAttribute(Driver, "mdPage", "Title");
            if (title.Equals("MultiPage Test"))
            {
                result = true;
                ClickLeftToolbarItem();
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void PushAndPushTest()
        {
            bool result = false;
            WebElementUtils.Click(Driver, "button2");
            string title = WebElementUtils.GetAttribute(Driver, "page3", "Title");
            if (title.Equals("B page"))
            {
                result = true;
                ClickLeftToolbarItem();
            }

            title = WebElementUtils.GetAttribute(Driver, "page2", "Title");
            if (title.Equals("A page"))
            {
                ClickRightToolbarItem();
            }
            else
            {
                result = false;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void PushandInsertBeforeTest()
        {
            bool result = false;
            WebElementUtils.Click(Driver, "button3");
            string title = WebElementUtils.GetAttribute(Driver, "page2", "Title");
            if (title.Equals("A page"))
            {
                result = true;
                ClickRightToolbarItem();
            }

            title = WebElementUtils.GetAttribute(Driver, "page3", "Title");
            if (title.Equals("B page"))
            {
                ClickLeftToolbarItem();
            }
            else
            {
                result = false;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }
    }
}

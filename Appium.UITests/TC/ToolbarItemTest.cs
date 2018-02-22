using OpenQA.Selenium.Remote;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ToolbarItemTest
    {
        string PlatformName;
        AppiumDriver Driver;
        RemoteTouchScreen touch;
        int leftToolbarItemX = 100;
        int rightToolbarItemX = 660;
        int toolbarItemY = 90;

        public ToolbarItemTest(string platform)
        {
            PlatformName = platform;
        }

        void ClickToolbarItem()
        {
            touch.Down(leftToolbarItemX, toolbarItemY);
            touch.Up(leftToolbarItemX, toolbarItemY);
            System.Threading.Thread.Sleep(3000);
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
        public void AddPage1()
        {
            bool result = false;
            WebElementUtils.Click(Driver, "button1");
            string title = WebElementUtils.GetAttribute(Driver, "page1", "Title");
            if (title.Equals("Page1"))
            {
                result = true;
                ClickToolbarItem();
            }

            Driver.Driver.Navigate().Back();
            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void AddPage2()
        {
            bool result = false;
            WebElementUtils.Click(Driver, "button2");
            string title = WebElementUtils.GetAttribute(Driver, "page2", "Title");
            if (title.Equals("Page2"))
            {
                result = true;
                ClickToolbarItem();
            }

            Driver.Driver.Navigate().Back();
            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void AddPage3()
        {
            bool result = false;
            WebElementUtils.Click(Driver, "button3");
            string title = WebElementUtils.GetAttribute(Driver, "page3", "Title");
            if (title.Equals("Page3"))
            {
                result = true;
                ClickToolbarItem();
            }

            Driver.Driver.Navigate().Back();
            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void AddPage4()
        {
            bool result = false;
            WebElementUtils.Click(Driver, "button4");
            string title = WebElementUtils.GetAttribute(Driver, "page4", "Title");
            if (title.Equals("Page4"))
            {
                result = true;
                ClickToolbarItem();

                WebElementUtils.Click(Driver, "addItemButton");
                WebElementUtils.Click(Driver, "removeItemButton");
                WebElementUtils.Click(Driver, "changeTitleButton");

                string changedTitle = WebElementUtils.GetAttribute(Driver, "page4", "Title");
                System.Console.WriteLine("changedTitle : " + changedTitle);
                if (!changedTitle.Equals("Page4!"))
                {
                    result = false;
                }
            }

            Assert.AreEqual(result, true);
        }
    }
}

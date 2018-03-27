using OpenQA.Selenium.Remote;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ToolbarItemTest : TestTemplate
    {
        int leftToolbarItemX = 100;
        int rightToolbarItemX = 660;
        int toolbarItemY = 90;

        void ClickToolbarItem()
        {
            Driver.Click(leftToolbarItemX, toolbarItemY);
            System.Threading.Thread.Sleep(3000);

            Driver.Click(rightToolbarItemX, toolbarItemY);
            System.Threading.Thread.Sleep(3000);
        }

        [Test]
        public void AddPage1()
        {
            bool result = false;
            Driver.Click("button1");
            string title = Driver.GetAttribute<string>("page1", "Title");
            if (title.Equals("Page1"))
            {
                result = true;
                ClickToolbarItem();
            }

            Driver.GoBack();
            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void AddPage2()
        {
            bool result = false;
            Driver.Click("button2");
            string title = Driver.GetAttribute<string>("page2", "Title");
            if (title.Equals("Page2"))
            {
                result = true;
                ClickToolbarItem();
            }

            Driver.GoBack();
            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void AddPage3()
        {
            bool result = false;
            Driver.Click("button3");
            string title = Driver.GetAttribute<string>("page3", "Title");
            if (title.Equals("Page3"))
            {
                result = true;
                ClickToolbarItem();
            }

            Driver.GoBack();
            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void AddPage4()
        {
            bool result = false;
            Driver.Click("button4");
            string title = Driver.GetAttribute<string>("page4", "Title");
            if (title.Equals("Page4"))
            {
                result = true;
                ClickToolbarItem();

                Driver.Click("addItemButton");
                Driver.Click("removeItemButton");
                Driver.Click("changeTitleButton");

                string changedTitle = Driver.GetAttribute<string>("page4", "Title");
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

using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ToolbarItemTest2 : TestTemplate
    {
        int leftToolbarItemX = 100;
        int rightToolbarItemX = 660;
        int toolbarItemY = 90;

        void ClickLeftToolbarItem()
        {
            Driver.Click(leftToolbarItemX, toolbarItemY);
            System.Threading.Thread.Sleep(3000);
        }

        void ClickRightToolbarItem()
        {
            Driver.Click(rightToolbarItemX, toolbarItemY);
            System.Threading.Thread.Sleep(3000);
        }

        [Test]
        public void TestMultiPageToolbar()
        {
            bool result = false;
            Driver.Click("button1");
            string title = Driver.GetAttribute<string>("mdPage", "Title");
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
            Driver.Click("button2");
            string title = Driver.GetAttribute<string>("page3", "Title");
            if (title.Equals("B page"))
            {
                result = true;
                ClickLeftToolbarItem();
            }

            title = Driver.GetAttribute<string>("page2", "Title");
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
            Driver.Click("button3");
            string title = Driver.GetAttribute<string>("page2", "Title");
            if (title.Equals("A page"))
            {
                result = true;
                ClickRightToolbarItem();
            }

            title = Driver.GetAttribute<string>("page3", "Title");
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

using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ToolbarItemTest3 : TestTemplate
    {
        //All tests are done.Driver wil be closed
        [TestFixtureTearDown]
        public new void TestFixtureTearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void AddToolbarItem()
        {
            Driver.Click("addPrimaryItemButton");
            Driver.Click("addPrimaryItemButton2");

            Assert.AreEqual(true, true);
        }

        [Test]
        public void RemoveToolbarItem()
        {
            Driver.Click("removeItemButton");

            Assert.AreEqual(true, true);
        }

        [Test]
        public void ChangePriority()
        {
            Driver.Click("changeItemButton");

            Assert.AreEqual(true, true);
        }

        [Test]
        public void ChangeIcon()
        {
            Driver.Click("changeIconButton");

            Assert.AreEqual(true, true);
        }
    }
}

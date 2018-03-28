using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class LayoutAddRemoveTest2 : TestTemplate
    {
        [Test]
        public void AddTest()
        {
            var btnId = "addbtn";

            Driver.Click(btnId);

            var image = "LayoutAddRemoveTest2_addbtn.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void AddTaskTest()
        {
            var btnId = "addtaskbtn";

            Driver.Click(btnId);

            var image = "LayoutAddRemoveTest2_addtaskbtn.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void RemoveTest()
        {
            var addBtnId = "addbtn";
            var removeBtnId = "removebtn";

            Driver.Click(addBtnId);
            Driver.Click(removeBtnId);

            var image = "LayoutAddRemoveTest2_removebtn.png";
            Driver.CheckScreenshot(image);
        }
    }
}

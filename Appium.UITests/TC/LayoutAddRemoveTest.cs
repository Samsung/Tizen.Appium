using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class LayoutAddRemoveTest : TestTemplate
    {
        [Test]
        public void AddTest()
        {
            var addBtnId = "addbtn";

            Driver.Click(addBtnId);

            var image = "LayoutAddRemoveTest_addbtn.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void AddRemoveTest()
        {
            var addBtnId = "addbtn";
            var removeBtnId = "removebtn";

            Driver.Click(addBtnId);
            Driver.Click(removeBtnId);

            var image = "LayoutAddRemoveTest_removebtn.png";
            Driver.CheckScreenshot(image);
        }
    }
}

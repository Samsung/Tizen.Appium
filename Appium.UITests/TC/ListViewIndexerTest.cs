using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewIndexerTest : TestTemplate
    {
        [Test]
        public void Enable1Test()
        {
            var btnId = "enable1";
            var listId = "list";

            Driver.Click(btnId);

            var displayBinding = Driver.GetAttribute<string>(listId, "GroupDisplayBinding");
            var shortBinding = Driver.GetAttribute<string>(listId, "GroupDisplayBinding");

            var image = "ListViewIndexerTest_enable1.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void Enable2Test()
        {
            var btnId = "enable2";
            var listId = "list";

            Driver.Click(btnId);

            var displayBinding = Driver.GetAttribute<string>(listId, "GroupDisplayBinding");
            var shortBinding = Driver.GetAttribute<string>(listId, "GroupDisplayBinding");

            var image = "ListViewIndexerTest_enable2.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void Enable3Test()
        {
            var btnId = "enable3";
            var listId = "list";

            Driver.Click(btnId);

            var displayBinding = Driver.GetAttribute<string>(listId, "GroupDisplayBinding");
            var shortBinding = Driver.GetAttribute<string>(listId, "GroupDisplayBinding");

            var image = "ListViewIndexerTest_enable3.png";
            Driver.CheckScreenshot(image);
        }
    }
}

using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class BackgroundColorTest2 : TestTemplate
    {
        [Test]
        public void StackLayoutBackgroundTest()
        {
            string result = Driver.GetAttribute<string>("layout1", "BackgroundColor");
            Driver.Click("button1");
            string result2 = Driver.GetAttribute<string>("layout1", "BackgroundColor");
            //Assert.AreNotEqual(result, result2);
        }

        [Test]
        public void StackLayoutBackgroundTest2()
        {
            string result = Driver.GetAttribute<string>("layout2", "BackgroundColor");
            Driver.Click("button2");
            string result2 = Driver.GetAttribute<string>("layout2", "BackgroundColor");
            //Assert.AreNotEqual(result, result2);
        }
    }
}

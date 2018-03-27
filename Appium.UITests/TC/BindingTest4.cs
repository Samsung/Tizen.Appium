using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class BindingTest4 : TestTemplate
    {
        [Test]
        public void LabelBindingTest()
        {
            string ret = Driver.GetAttribute<string>("lb", "TextColor");
            Driver.Click("btn1");
            string ret2 = Driver.GetAttribute<string>("lb", "TextColor");
            Assert.AreNotEqual(ret, ret2);
        }

        [Test]
        public void ButtonBindingTest()
        {
            string ret = Driver.GetAttribute<string>("btn1", "TextColor");
            Driver.Click("btn1");
            string ret2 = Driver.GetAttribute<string>("btn1", "TextColor");
            Assert.AreNotEqual(ret, ret2);
        }

        [Test]
        public void EditorBindingTest()
        {
            string ret = Driver.GetAttribute<string>("editor", "TextColor");
            Driver.Click("btn1");
            string ret2 = Driver.GetAttribute<string>("editor", "TextColor");
            Assert.AreNotEqual(ret, ret2);
        }
    }
}

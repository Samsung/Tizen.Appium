using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class BindingTest3 : TestTemplate
    {
        [Test]
        public void BindingTest()
        {
            string ret = Driver.GetAttribute<string>("buttony", "Text");
            Driver.Click("buttony");
            string ret2 = Driver.GetAttribute<string>("buttony", "Text");
            Assert.AreNotEqual(ret, ret2);
        }

        [Test]
        public void BindingTest2()
        {
            string ret = Driver.GetAttribute<string>("buttonx", "Text");
            Driver.Click("buttonx");
            string ret2 = Driver.GetAttribute<string>("buttonx", "Text");
            Assert.AreNotEqual(ret, ret2);
        }
    }
}

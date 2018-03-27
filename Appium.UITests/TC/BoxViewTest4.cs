using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class BoxViewTest4 : TestTemplate
    {
        [Test]
        public void ScaleTest1()
        {
            string ret = Driver.GetAttribute<string>("box", "Scale");
            Driver.Click("button");
            Driver.Click("button");
            string ret2 = Driver.GetAttribute<string>("box", "Scale");
        }

        [Test]
        public void ScaleTest2()
        {
            string ret = Driver.GetAttribute<string>("box", "Scale");
            Driver.Click("button2");
            Driver.Click("button2");
            string ret2 = Driver.GetAttribute<string>("box", "Scale");
        }
    }
}

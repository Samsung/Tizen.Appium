using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class BindingTest1 : TestTemplate
    {
        [Test]
        public void BindingTest()
        {
            string box1Ret = Driver.GetAttribute<string>("box1", "IsVisible");
            string box2Ret = Driver.GetAttribute<string>("box2", "IsVisible");
            Driver.Click("btn");

            string box1Ret2 = Driver.GetAttribute<string>("box1", "IsVisible");
            string box2Ret2 = Driver.GetAttribute<string>("box2", "IsVisible");
            Assert.AreNotEqual(box1Ret, box1Ret2);
            Assert.AreNotEqual(box2Ret, box2Ret2);
        }
    }
}

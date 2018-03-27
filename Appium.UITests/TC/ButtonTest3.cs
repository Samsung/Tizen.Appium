using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ButtonTest3 : TestTemplate
    {
        [Test]
        public void ClickTest()
        {
            Driver.Click("button");
            string result = Driver.GetAttribute<string>("label", "Text");
            Assert.AreEqual("Test Button.Command", result);
        }
    }
}

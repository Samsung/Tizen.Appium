using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ButtonTest5 : TestTemplate
    {
        [Test]
        public void ClickTest()
        {
            string before = Driver.GetAttribute<string>("btnOpacitySlider", "Value");
            Assert.AreEqual("1", before);

            Driver.Click("button");
            string after = Driver.GetAttribute<string>("btnOpacitySlider", "Value");
            Assert.AreEqual("0.5", after);
        }
    }
}

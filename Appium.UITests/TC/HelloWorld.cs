using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class HelloWorld : TestTemplate
    {
        [Test]
        public void TextTest()
        {
            string result = Driver.GetText("label");
            Assert.AreEqual("Hello Xamarin for Tizen", result);
        }
    }
}

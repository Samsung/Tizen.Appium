using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class BackgroundImageTest : TestTemplate
    {
        [Test]
        public void ActivityIndicatorBackgroundTest()
        {
            string result = Driver.GetAttribute<string>("ContentPage", "BackgroundImage");
            Driver.Click("button1");
            string result2 = Driver.GetAttribute<string>("ContentPage", "BackgroundImage");
            Assert.AreNotEqual(result, result2);
        }
    }
}

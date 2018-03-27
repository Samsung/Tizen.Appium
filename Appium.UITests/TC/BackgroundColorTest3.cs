using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class BackgroundColorTest3 : TestTemplate
    {
        [Test]
        public void ContentPageBackgroundTest()
        {
            string result = Driver.GetAttribute<string>("ContentPage", "BackgroundColor");
            Driver.Click("button1");
            string result2 = Driver.GetAttribute<string>("ContentPage", "BackgroundColor");
            Assert.AreNotEqual(result, result2);
        }
    }
}

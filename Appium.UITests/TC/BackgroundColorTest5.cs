using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class BackgroundColorTest5 : TestTemplate
    {
        [Test]
        public void ActivityIndicatorBackgroundTest()
        {
            string result = Driver.GetAttribute<string>("ai", "BackgroundColor");
            Driver.Click("button1");
            string result2 = Driver.GetAttribute<string>("ai", "BackgroundColor");
            Assert.AreNotEqual(result, result2);
        }

        [Test]
        public void LabelBackgroundTest()
        {
            string result = Driver.GetAttribute<string>("label", "BackgroundColor");
            Driver.Click("button1");
            string result2 = Driver.GetAttribute<string>("label", "BackgroundColor");
            Assert.AreNotEqual(result, result2);
        }

        [Test]
        public void EntryBackgroundTest()
        {
            string result = Driver.GetAttribute<string>("entry", "BackgroundColor");
            Driver.Click("button1");
            string result2 = Driver.GetAttribute<string>("entry", "BackgroundColor");
            Assert.AreNotEqual(result, result2);
        }

        [Test]
        public void SliderBackgroundTest()
        {
            string result = Driver.GetAttribute<string>("slider", "BackgroundColor");
            Driver.Click("button1");
            string result2 = Driver.GetAttribute<string>("slider", "BackgroundColor");
            Assert.AreNotEqual(result, result2);
        }

        [Test]
        public void ProgressBarBackgroundTest()
        {
            string result = Driver.GetAttribute<string>("progress", "BackgroundColor");
            Driver.Click("button1");
            string result2 = Driver.GetAttribute<string>("progress", "BackgroundColor");
            Assert.AreNotEqual(result, result2);
        }
    }
}

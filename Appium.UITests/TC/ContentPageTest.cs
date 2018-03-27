using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ContentPageTest : TestTemplate
    {
        [Test]
        public void ContentTest()
        {
            Driver.Click("one");
            Driver.Click("two");
            string ret = Driver.GetAttribute<string>("one", "Text");
            Assert.AreEqual("ONE", ret);
        }
    }
}

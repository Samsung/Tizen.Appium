using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ContentPageTest2 : TestTemplate
    {
        [Test]
        public void ContentTest()
        {
            string ret = Driver.GetAttribute<string>("header", "Text");
            Assert.AreEqual("Template header", ret);

            ret = Driver.GetAttribute<string>("ContentViewContent", "Text");
            Assert.AreEqual("This is a content", ret);

            ret = Driver.GetAttribute<string>("footer", "Text");
            Assert.AreEqual("Template fotter", ret);
        }
    }
}

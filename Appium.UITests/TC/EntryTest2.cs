using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class EntryTest2 : TestTemplate
    {
        [Test]
        public void GetTextTest()
        {
            string result = Driver.GetText("entry");
            Assert.AreEqual("This is Entry", result);
        }
    }
}

using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class FocusSetTest : TestTemplate
    {
        [Test]
        public void FocusTest()
        {
            Driver.Click("First -> Fourth");
            string result = Driver.GetText("Fourth -> Second");
            Assert.AreEqual("Focused!!", result);

            Driver.Click("Fourth -> Second");
            result = Driver.GetText("Second -> Third");
            Assert.AreEqual("Focused!!", result);

            Driver.Click("Second -> Third");
            result = Driver.GetText("Third -> First");
            Assert.AreEqual("Focused!!", result);

            Driver.Click("Third -> First");
            result = Driver.GetText("First -> Fourth");
            Assert.AreEqual("Focused!!", result);
        }
    }
}

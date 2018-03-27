using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class FrameTest1 : TestTemplate
    {
        [Test]
        public void HasShowdowTest()
        {
            Driver.Click("btnHasShadow");
            var result = Driver.GetAttribute<bool>("_frame", "HasShadow");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void HasNoShowdowTest()
        {
            Driver.Click("btnHasNoShadow");
            var result = Driver.GetAttribute<bool>("_frame", "HasShadow");
            Assert.AreEqual(false, result);
        }
    }
}

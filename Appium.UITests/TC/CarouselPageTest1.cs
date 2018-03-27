using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class CarouselPageTest1 : TestTemplate
    {
        [Test]
        public void CurrentPageTest()
        {
            Driver.Flick(-10, 0);
            Driver.Flick(-10, 0);
            Driver.Flick(-10, 0);

            string ret = Driver.GetAttribute<string>("BlueLabel", "Text");
            Assert.AreEqual("Blue", ret);
        }
    }
}

using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class SliderTest1 : TestTemplate
    {
        [Test]
        public void IncreaseTest()
        {
            var btnId = "button1";
            var sliderId = "slider";

            var before = Driver.GetAttribute<double>(sliderId, "Value");

            Driver.Click(btnId);

            var after = Driver.GetAttribute<double>(sliderId, "Value");

            Assert.True(((before + 3) == after), "Value should be " + (before + 3));
        }

        [Test]
        public void DecreaseTest()
        {
            var inBtnId = "button1";
            var deBtnId = "button2";
            var sliderId = "slider";

            var before = Driver.GetAttribute<double>(sliderId, "Value");

            Driver.Click(inBtnId);
            Driver.Click(inBtnId);

            Driver.Click(deBtnId);

            var after = Driver.GetAttribute<double>(sliderId, "Value");

            Assert.True(((before + 3) == after), "Value should be " + (before + 3));
        }
    }
}

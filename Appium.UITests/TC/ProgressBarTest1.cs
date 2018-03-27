using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ProgressBarTest1 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var pregressbarId = "progressBar";
            var btnid = "playAnimation";
            var value = 1;

            Driver.Click(btnid);

            var result = Driver.GetAttribute<double>(pregressbarId, "Progress");
            Assert.True((value == result), "value should be " + result);
        }

        [Test]
        public void ChangeValueTest()
        {
            var pregressbarId = "progressBar";
            var sliderId = "slider";
            var value = 0.5;

            Driver.SetAttribute(sliderId, "Value", value);

            var result = Driver.GetAttribute<double>(pregressbarId, "Progress");

            Assert.True((value == result), "value should be " + result);
        }
    }
}

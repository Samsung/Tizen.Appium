using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class DensityIndependentTest2 : TestTemplate
    {
        [Test]
        public void FontSizeTest()
        {
            double ret = Driver.GetAttribute<double>("label1", "FontSize");
            Assert.AreEqual(18, (int)ret);
        }

        [Test]
        public void FontSizeTest2()
        {
            double ret = Driver.GetAttribute<double>("label2", "FontSize");
            Assert.AreEqual(14, (int)ret);
        }

        [Test]
        public void FontSizeTest3()
        {
            double ret = Driver.GetAttribute<double>("label3", "FontSize");
            Assert.AreEqual(13, (int)ret);
        }

        [Test]
        public void FontSizeTest4()
        {
            double ret = Driver.GetAttribute<double>("label4", "FontSize");
            Assert.AreEqual(11, (int)ret);
        }
    }
}

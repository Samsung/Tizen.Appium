using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ImageTest2 : TestTemplate
    {
        [Test]
        public void AspectFitTest()
        {
            Driver.Click("aspectFit");
            string expect = "AspectFit";
            string ret = Driver.GetAttribute<string>("image", "Aspect");
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void AspectFillTest()
        {
            Driver.Click("aspectFill");
            string expect = "AspectFill";
            string ret = Driver.GetAttribute<string>("image", "Aspect");
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void FillTest()
        {
            Driver.Click("fill");
            string expect = "Fill";
            string ret = Driver.GetAttribute<string>("image", "Aspect");
            Assert.AreEqual(expect, ret);
        }
    }
}

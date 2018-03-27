using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class LabelTest6 : TestTemplate
    {
        [Test]
        public void BoldTest()
        {
            Driver.Click("boldBtn");
        }

        [Test]
        public void ItalicTest()
        {
            Driver.Click("italic");
        }

        [Test]
        public void LargerFontTest()
        {
            Driver.Click("largerFont");
        }

        [Test]
        public void SmallerFontTest()
        {
            Driver.Click("smallerFont");
        }

        [Test]
        public void WordWrapTest()
        {
            Driver.Click("wordWrap");
        }

        [Test]
        public void CharWrapTest()
        {
            Driver.Click("charWrap");
        }

        [Test]
        public void HeadWrapTest()
        {
            Driver.Click("headWrap");
        }

        [Test]
        public void MiddleWrapTest()
        {
            Driver.Click("middleWrap");
        }

        [Test]
        public void NoWrapTest()
        {
            Driver.Click("noWrap");
        }
    }
}

using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class KeyboardTest1 : TestTemplate
    {
        [Test]
        public void ChatKeyboardTest()
        {
            Driver.Click("btnDefault");
            Driver.Click("btnKeyBorChat");
            Driver.Click(326, 283);
        }

        [Test]
        public void DefaultKeyboardTest()
        {
            Driver.Click("btnDefault");
            Driver.Click(326, 283);
        }

        [Test]
        public void EmailKeyboardTest()
        {
            Driver.Click("btnDefault");
            Driver.Click("btnEmail");
            Driver.Click(326, 283);
        }

        [Test]
        public void NumericKeyboardTest()
        {
            Driver.Click("btnDefault");
            Driver.Click("btnNumeric");
            Driver.Click(326, 283);
        }

        [Test]
        public void PlainKeyboardTest()
        {
            Driver.Click("btnDefault");
            Driver.Click("btnPlain");
            Driver.Click(326, 283);
        }

        [Test]
        public void TelephoneKeyboardTest()
        {
            Driver.Click("btnDefault");
            Driver.Click("btnTelephone");

            Driver.Click(326, 283);
        }

        [Test]
        public void TextKeyboardTest()
        {
            Driver.Click("btnDefault");
            Driver.Click("btnText");

            Driver.Click(326, 283);
        }

        [Test]
        public void UrlKeyboardTest()
        {
            Driver.Click("btnDefault");
            Driver.Click("btnUrl");

            Driver.Click(326, 283);
        }
    }
}

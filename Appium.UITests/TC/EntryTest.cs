using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class EntryTest : TestTemplate
    {
        [Test]
        public void SetTextTest()
        {
            string before = Driver.GetText("emptyEntry");
            string addString = "ABCDEFG";
            Driver.SetText("emptyEntry", addString);

            EntryUnfocused();

            string after = Driver.GetText("emptyEntry");
            Assert.AreEqual(before + addString, after);
        }

        [Test]
        public void SetTextTest2()
        {
            string before = Driver.GetText("passwdEntry");
            string addString = "ABCDEFG";
            Driver.SetText("passwdEntry", addString);

            EntryUnfocused();

            string after = Driver.GetText("passwdEntry");
            Assert.AreEqual(before + addString, after);
        }

        [Test]
        public void GetTextTest()
        {
            string result = Driver.GetText("longEntry");
            Assert.AreEqual("This is a Entry with very looooooooooooong looooooooooooooong text", result);
        }

        void EntryUnfocused()
        {
            Driver.Click(240, 187);
        }
    }
}

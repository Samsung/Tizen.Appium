using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class EditorTest2 : TestTemplate
    {
        [Test]
        public void SetTextTest()
        {
            var longEditorId = "longEditor";
            var editorId = "editor";
            string add = "abcdefg";

            string origin = Driver.GetText(longEditorId);

            Driver.SetText(longEditorId, add);

            Driver.Click(editorId);
            string result = Driver.GetText(longEditorId);
            Assert.AreEqual(origin + add, result);
        }

        [Test]
        public void CompletedTest()
        {
            var longEditorId = "longEditor";
            var editorId = "editor";
            string add = "ABC";

            Driver.SetText(longEditorId, add);
            Driver.Click(editorId);

            Driver.Click(longEditorId);
            string result = Driver.GetText(editorId);

            Assert.AreEqual("Editing completed", result);
        }
    }
}

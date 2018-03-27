using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class EditorTest1 : TestTemplate
    {
        [Test]
        public void GetTextTest()
        {
            string result = Driver.GetText("editor");
            Assert.AreEqual("Plase, input any sentence.", result);
        }

        void GetTextTest2()
        {
            string origin = "This test is for testing Editor with very long text. This software is the confidential and proprietary information of Samsung Electronics, Inc. You shall not disclose such Confidential Information and shall use it only in accordance with the terms of the license agreement you entered into with Samsung.";
            string result = Driver.GetText("internalEditor");
            Assert.AreEqual(origin, result);
        }
    }
}

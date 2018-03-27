using NUnit.Framework;
using System;

namespace Appium.UITests
{
    [TestFixture]
    public class ButtonTest1 : TestTemplate
    {
        [Test]
        public void ClickTest()
        {
            Driver.Click("btnColored");
        }

        [Test]
        public void ClickTest2()
        {
            Driver.Click("btnTxtToggle");
            string result = Driver.GetText("btnTxtToggle");
            Assert.AreEqual(result, string.Empty);
        }

        [Test]
        public void ClickTest3()
        {
            Driver.Click("btnImgToggle");
            string result = Driver.GetAttribute<string>("btnImgToggle", "Image");
            Assert.True(String.IsNullOrEmpty(result));
        }

        [Test]
        public void ClickTest4()
        {
            Driver.Click("btnDisableToggle");
            bool result = Driver.GetAttribute<bool>("btnDisableTarget", "IsEnabled");
            Assert.AreEqual(true, result);

            Driver.Click("btnDisableTarget");
        }
    }
}

using NUnit.Framework;
using System;

namespace Appium.UITests
{
    [TestFixture]
    public class MasterDetailedTest3 : TestTemplate
    {
        [Test]
        public void ToggleTest()
        {
            var pageId = "MasterDetailPage";
            var masterBtnId = "master_button1";
            var togglBtnId = "detail_button1";

            var isPresented = Driver.GetAttribute<bool>(pageId, "IsPresented");

            if (isPresented)
            {
                Driver.Click(masterBtnId);
            }

            isPresented = Driver.GetAttribute<bool>(pageId, "IsPresented");
            Assert.False(Convert.ToBoolean(isPresented), "IsPresented should not be false, but got " + isPresented);

            Driver.Click(togglBtnId);

            isPresented = Driver.GetAttribute<bool>(pageId, "IsPresented");
            Assert.True(Convert.ToBoolean(isPresented), "IsPresented should not be true, but got " + isPresented);

            var image = "MasterDetailedTest3_toggle.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void ChangeTest()
        {
            var pageId = "MasterDetailPage";
            var togglBtnId = "detail_button1";
            var masterBtnId = "master_button1";
            var changeBtnId = "detail_button2";

            var isPresented = Driver.GetAttribute<bool>(pageId, "IsPresented");

            if (isPresented)
            {
                Driver.Click(masterBtnId);
            }

            isPresented = Driver.GetAttribute<bool>(pageId, "IsPresented");
            Assert.False(Convert.ToBoolean(isPresented), "IsPresented should not be false, but got " + isPresented);

            Driver.Click(changeBtnId);
            Driver.Click(togglBtnId);

            isPresented = Driver.GetAttribute<bool>(pageId, "IsPresented");
            Assert.True(Convert.ToBoolean(isPresented), "IsPresented should not be true, but got " + isPresented);

            var image = "MasterDetailedTest3_change.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void RestoreTest()
        {
            var pageId = "MasterDetailPage";
            var masterBtnId = "master_button1";
            var togglBtnId = "detail_button1";
            var restoreBtnId = "detail_button3";

            var isPresented = Driver.GetAttribute<bool>(pageId, "IsPresented");
            if (isPresented)
            {
                Driver.Click(masterBtnId);
            }

            isPresented = Driver.GetAttribute<bool>(pageId, "IsPresented");
            Assert.False(Convert.ToBoolean(isPresented), "IsPresented should not be false, but got " + isPresented);

            Driver.Click(restoreBtnId);
            Driver.Click(togglBtnId);

            isPresented = Driver.GetAttribute<bool>(pageId, "IsPresented");
            Assert.True(Convert.ToBoolean(isPresented), "IsPresented should not be true, but got " + isPresented);

            var image = "MasterDetailedTest3_restore.png";
            Driver.CheckScreenshot(image);
        }
    }
}

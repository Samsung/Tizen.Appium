using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class DatePickerTest : TestTemplate
    {
        [Test]
        public void DateTest()
        {
            string before = Driver.GetAttribute<string>("datePicker", "Date");

            ChangeDate();

            string after = Driver.GetAttribute<string>("datePicker", "Date");
            Assert.AreNotEqual(before, after);
        }

        [Test]
        public void SetDateTest()
        {
            Driver.Click("button");
            string before = Driver.GetAttribute<string>("datePicker", "Date");

            ChangeDate();

            string after = Driver.GetAttribute<string>("datePicker", "Date");
            Assert.AreNotEqual(before, after);
        }

        void ChangeDate()
        {
            // Click DatePicker
            Driver.Click(369, 267);

            // Change month
            Driver.Click(361, 811);

            // click "Set" button
            Driver.Click(549, 1224);
        }
    }
}

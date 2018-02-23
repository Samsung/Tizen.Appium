using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions.Internal;
using System.Drawing;
using System.Threading.Tasks;

namespace Xamarin.Issues.UITests
{
    public class TestScriptUtils
    {
        static RemoteTouchScreenUtils touchScreen;

        public const string Platform = "Tizen";

        public TestScriptUtils(AppiumDriver driver)
        {
        }

        public static void FindTC(AppiumDriver driver, string testName, int speed = -3)
        {
            touchScreen = new RemoteTouchScreenUtils(driver);

            string testId = WebElementUtils.GetAttribute(driver, "Content", testName);
            while (testId == string.Empty)
            {
                touchScreen.Flick(0, speed);
                testId = WebElementUtils.GetAttribute(driver, "Content", testName);
            }

            Task t = Task.Run(() =>
            {
                WebElementUtils.Click(driver, testId);
            });

            TimeSpan ts = TimeSpan.FromMilliseconds(4000);
            if (!t.Wait(ts))
            {
                touchScreen.Flick(0, -1);
                WebElementUtils.Click(driver, testId);
            }
            return;
        }
    }
}

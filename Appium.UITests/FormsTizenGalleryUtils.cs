using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions.Internal;
using System.Drawing;
using System;
using System.Threading.Tasks;

namespace Appium.UITests
{
    public class FormsTizenGalleryUtils
    {
        static RemoteTouchScreenUtils touchScreen;

        public FormsTizenGalleryUtils(AppiumDriver driver)
        {
        }

        public static void FindTC(AppiumDriver driver, string testName, int speed = -3)
        {
            string testId = string.Empty;
            touchScreen = new RemoteTouchScreenUtils(driver);

            Task t = Task.Run(() =>
            {
                while (testId == string.Empty)
               {
                   touchScreen.Flick(0, speed);
                   testId = WebElementUtils.GetAttribute(driver, "Content", testName);
               }
               WebElementUtils.Click(driver, testId);
            });

            TimeSpan ts = TimeSpan.FromMilliseconds(30000);
            if (!t.Wait(ts))
            {
                touchScreen.Flick(0, -1);
                WebElementUtils.Click(driver, testId);
            }
            return;
        }
    }
}

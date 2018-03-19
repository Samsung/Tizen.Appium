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

namespace Appium.UITests
{
    public class FormsTizenGalleryUtils
    {
        static RemoteTouchScreenUtils touchScreen;

        public const string Platform = "Tizen";

        public FormsTizenGalleryUtils(AppiumDriver driver)
        {
        }

        public static void FindTC(AppiumDriver driver, string testName, int speed = -3)
        {
            touchScreen = new RemoteTouchScreenUtils(driver);

            bool enabled = WebElementUtils.GetAttribute<bool>(driver, testName, "IsEnabled");

            while (!enabled)
            {
                touchScreen.Flick(0, speed);
                System.Threading.Thread.Sleep(1000);
                enabled = WebElementUtils.GetAttribute<bool>(driver, testName, "IsEnabled");
            }

            WebElementUtils.Click(driver, testName);
            System.Threading.Thread.Sleep(2000);
        }
    }
}

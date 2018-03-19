using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions.Internal;

namespace Xamarin.Issues.UITests
{
    public class AppiumDriver
    {
        string PlatformName;
        public AppiumDriver<AppiumWebElement> Driver;

        public AppiumDriver(string platform)
        {
            PlatformName = platform;
            if (PlatformName.CompareTo("Android") != 0)
            {
                Driver = CreateTizenDriver();
            }
            else
            {
                Driver = CreateAndroidDriver();
            }
        }

        public void Quit()
        {
            Driver.Quit();
        }

        public AppiumWebElement GetWebElement(string id)
        {
            return Driver.FindElementByAccessibilityId(id);
        }

        public AppiumDriver<AppiumWebElement> CreateTizenDriver()
        {
            DesiredCapabilities capabillities = new DesiredCapabilities();
            if (PlatformName.Equals("Tizen"))
            {
                capabillities.SetCapability("deviceName", "0000d84200006200");
            }
            else
            {
                capabillities.SetCapability("deviceName", "emulator-26101");
            }
            capabillities.SetCapability("platformName", "Tizen");
            capabillities.SetCapability("appPackage", "org.tizen.xamarin.forms.issues.tizen");
            capabillities.SetCapability("app", "Xamarin.Forms.Tizen.Issues-1.0.0.tpk");
            var driver = new TizenDriver<AppiumWebElement>(new Uri("http://192.168.0.49:8080/wd/hub"), capabillities);
            return driver;
        }

        public AppiumDriver<AppiumWebElement> CreateAndroidDriver()
        {
            DesiredCapabilities capabillities = new DesiredCapabilities();
            capabillities.SetCapability("deviceName", "emulator-5554");
            capabillities.SetCapability("platformName", "Android");
            capabillities.SetCapability("appPackage", "AppiumTest.Android");
            capabillities.SetCapability("appActivity", "md5fb91949aa2c8850087e612420184ba95.MainActivity");
            var driver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabillities, TimeSpan.FromMinutes(5));
            return driver;
        }
    }
}

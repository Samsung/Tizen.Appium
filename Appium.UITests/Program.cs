using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace Appium.UITests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Excuting Appium Script");

            var driver = CreateTizenDriver();
            //var driver = CreateAndroidDriver();
            ExecuteTest(driver);
        }

        static AppiumDriver<AppiumWebElement> CreateTizenDriver()
        {
            DesiredCapabilities capabillities = new DesiredCapabilities();
            capabillities.SetCapability("deviceName", "0000d84200006200");
            capabillities.SetCapability("platformName", "Tizen");
            capabillities.SetCapability("appPackage", "org.tizen.example.Calculator.Tizen.Mobile");
            var driver = new TizenDriver<AppiumWebElement>(new Uri("http://10.113.62.173:8080/wd/hub"), capabillities);
            return driver;
        }

        static AppiumDriver<AppiumWebElement> CreateAndroidDriver()
        {
            DesiredCapabilities capabillities = new DesiredCapabilities();
            capabillities.SetCapability("deviceName", "emulator-5554");
            capabillities.SetCapability("platformName", "Android");
            capabillities.SetCapability("appPackage", "Calculator.Android");
            capabillities.SetCapability("appActivity", "md570202206b1642cdde93943af1490fb24.MainActivity");
            var driver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabillities, TimeSpan.FromMinutes(5));
            return driver;
        }

        static void ExecuteTest(AppiumDriver<AppiumWebElement> driver)
        {
            //int sleepTime = 1000;

            driver.FindElementByAccessibilityId("8").Click();
            //System.Threading.Thread.Sleep(sleepTime);
            driver.FindElementByAccessibilityId("*").Click();
            //System.Threading.Thread.Sleep(sleepTime);
            driver.FindElementByAccessibilityId("5").Click();
            //System.Threading.Thread.Sleep(sleepTime);
            driver.FindElementByAccessibilityId("Equal").Click();
            //System.Threading.Thread.Sleep(sleepTime);

            //string Result = driver.FindElementByAccessibilityId("ResultText").Text;
            //Console.WriteLine("@@@@@@RESULT : " + Result);

            
            driver.FindElementByAccessibilityId("1").Click();
            //System.Threading.Thread.Sleep(sleepTime);
            driver.FindElementByAccessibilityId("2").Click();
            //System.Threading.Thread.Sleep(sleepTime);
            driver.FindElementByAccessibilityId("3").Click();
            //System.Threading.Thread.Sleep(sleepTime);
            driver.FindElementByAccessibilityId("-").Click();
            //System.Threading.Thread.Sleep(sleepTime);
            driver.FindElementByAccessibilityId("4").Click();
            //System.Threading.Thread.Sleep(sleepTime);
            driver.FindElementByAccessibilityId("5").Click();
            //System.Threading.Thread.Sleep(sleepTime);
            driver.FindElementByAccessibilityId("Equal").Click();
            //System.Threading.Thread.Sleep(sleepTime);

            driver.FindElementByAccessibilityId("6").Click();
            //System.Threading.Thread.Sleep(sleepTime);
            driver.FindElementByAccessibilityId("7").Click();
            //System.Threading.Thread.Sleep(sleepTime);
            driver.FindElementByAccessibilityId("8").Click();
            //System.Threading.Thread.Sleep(sleepTime);
            driver.FindElementByAccessibilityId("+").Click();
            //System.Threading.Thread.Sleep(sleepTime);
            driver.FindElementByAccessibilityId("9").Click();
            //System.Threading.Thread.Sleep(sleepTime);
            driver.FindElementByAccessibilityId("0").Click();
            //System.Threading.Thread.Sleep(sleepTime);
            driver.FindElementByAccessibilityId("Equal").Click();
            //System.Threading.Thread.Sleep(sleepTime);

            //System.Threading.Thread.Sleep(sleepTime);
            

            driver.Quit();
        }
    }
}

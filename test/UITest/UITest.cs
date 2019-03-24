using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;

namespace UITest
{
    public class UITest
    {
        TizenDriver<TizenElement> _driver;

        [SetUp]
        public void Setup()
        {
            AppiumOptions appiumOptions = new AppiumOptions();

            appiumOptions.AddAdditionalCapability("platformName", "Tizen");
            appiumOptions.AddAdditionalCapability("deviceName", "emulator-26101");

            //Xamarin.Forms
            appiumOptions.AddAdditionalCapability("appPackage", "org.tizen.example.FormsApp.Tizen.Mobile");

            //ElmSharp
            //appiumOptions.AddAdditionalCapability("appPackage", "org.tizen.example.ElmSharpApp");

            //NUI
            //appiumOptions.AddAdditionalCapability("appPackage", "org.tizen.example.NUIApp");

            _driver = new TizenDriver<TizenElement>(new Uri("http://127.0.0.1:4723/wd/hub"), appiumOptions);
        }

        [Test]
        public void Test1()
        {
            _driver.FindElementByAccessibilityId("Button").Click();
            System.Threading.Thread.Sleep(3000);
        }
    }
}

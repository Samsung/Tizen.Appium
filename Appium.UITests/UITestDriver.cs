using System;
using System.IO;
using System.Drawing;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium;

using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;

namespace Appium.UITests
{
    public sealed class UITestDriver // to communicate appium
    {
        const int DelayTime = 1000;
        const string Platform = "Tizen";

        static UITestDriver _instance;
        AppiumDriver<AppiumWebElement> _driver;
        RemoteTouchScreen _touchScreen;

        public static UITestDriver Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UITestDriver(Platform, "");
                }
                return _instance;
            }
        }

        public static string Profile { get; private set; }

        public RemoteTouchScreen TouchScreen
        {
            get
            {
                return _touchScreen;
            }
        }

        UITestDriver(string platform = "", string profile = "")
        {
            if (platform == "Android")
            {
                InitAndroid(platform, profile);
            }
            else
            {
                InitTizen(platform, profile);
            }
        }

        void InitTizen(string platform, string profile)
        {
            DesiredCapabilities capabillities = new DesiredCapabilities();

            capabillities.SetCapability("platformName", platform);
            capabillities.SetCapability("deviceName", "0000d84200006200");
            //capabillities.SetCapability("deviceName", "emulator-26101");
            capabillities.SetCapability("appPackage", "org.tizen.example.FormsTizenGallery.Tizen");
            capabillities.SetCapability("app", "FormsTizenGallery.Tizen-1.0.0.tpk");
            _driver = new TizenDriver<AppiumWebElement>(new Uri("http://192.168.0.49:4723/wd/hub"), capabillities);
            //_driver = new TizenDriver<AppiumWebElement>(new Uri("http://10.113.113.120:4723/wd/hub"), capabillities);
            _touchScreen = new RemoteTouchScreen(_driver);
        }

        void InitAndroid(string platform, string profile)
        {
            DesiredCapabilities capabillities = new DesiredCapabilities();
            capabillities.SetCapability("platformName", platform);
            capabillities.SetCapability("deviceName", "emulator-5554");
            capabillities.SetCapability("appPackage", "AppiumTest.Android");
            capabillities.SetCapability("appActivity", "md5fb91949aa2c8850087e612420184ba95.MainActivity");
            _driver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabillities, TimeSpan.FromMinutes(5));
            _touchScreen = new RemoteTouchScreen(_driver);
        }

        public void Quit()
        {
            _driver.Quit();
        }

        public void GoBack()
        {
            _driver.Navigate().Back();
        }

        public void GoHomePage()
        {
            var MainPageEnabled = GetAttribute<bool>("MainPage", "IsEnabled");
            if (!MainPageEnabled)
            {
                Assert.Fail("Not Found MainPage");
            }

            var currentPage = GetAttribute<string>("MainPage", "CurrentPage");
            while (currentPage.IndexOf("HomePage") == -1)
            {
                _driver.Navigate().Back();
                System.Threading.Thread.Sleep(1000);
                currentPage = GetAttribute<string>("MainPage", "CurrentPage");
            }
        }

        public void FindTC(string testName, int speed = -3)
        {
            var MainPageEnabled = GetAttribute<bool>("MainPage", "IsEnabled");
            if (!MainPageEnabled)
            {
                Assert.Fail("Not Found MainPage");
            }

            var enabled = GetAttribute<bool>(testName, "IsEnabled");

            var lastTcEnabled = GetAttribute<bool>("ToolbarItemTest3", "IsEnabled");

            while (!enabled)
            {
                _touchScreen.Flick(0, speed);
                System.Threading.Thread.Sleep(1000);
                enabled = GetAttribute<bool>(testName, "IsEnabled");
                lastTcEnabled = GetAttribute<bool>("ToolbarItemTest3", "IsEnabled");
                if ((lastTcEnabled) && (!enabled))
                {
                    Assert.Fail("Not Found TC");
                }
            }

            Click(testName);
        }

        public void Flick(int speedX, int speedY, int delay = DelayTime)
        {
            _touchScreen.Flick(speedX, speedY);
            System.Threading.Thread.Sleep(delay);
        }

        public void Click(int x, int y, int delay = DelayTime)
        {
            _touchScreen.Down(x, y);
            _touchScreen.Up(x, y);
            System.Threading.Thread.Sleep(delay);
        }

        public void Click(string automationId, int delay = DelayTime)
        {
            var element = _driver.FindElementByAccessibilityId(automationId);
            var x = element.Location.X;
            var y = element.Location.Y;
            _touchScreen.Down(x, y);
            _touchScreen.Up(x, y);
            System.Threading.Thread.Sleep(delay);
        }

        public void Drag(int startX, int startY, int endX, int endY, int delayTime = DelayTime)
        {
            _touchScreen.Down(startX, startY);
            System.Threading.Thread.Sleep(delayTime);
            _touchScreen.Move(endX, endX);
            System.Threading.Thread.Sleep(delayTime);
            _touchScreen.Up(endX, endX);
        }

        public void SetText(string automationId, string text, int delayTime = DelayTime)
        {
            var element = _driver.FindElementByAccessibilityId(automationId);
            var x = element.Location.X;
            var y = element.Location.Y;
            _touchScreen.Down(x, y);
            _touchScreen.Up(x, y);
            _driver.Keyboard.SendKeys(text);
            System.Threading.Thread.Sleep(delayTime);
        }

        public T GetAttribute<T>(string automationId, string attribute, int delayTime = DelayTime)
        {
            System.Threading.Thread.Sleep(delayTime);
            var element = _driver.FindElementByAccessibilityId(automationId);
            var stringValue = element.GetAttribute(attribute);

            if (!String.IsNullOrEmpty(stringValue))
            {
                T value = (T)Convert.ChangeType(stringValue, typeof(T));
                return value;
            }

            return default(T);
        }

        public Point GetLocation(string automationId, int delayTime = DelayTime)
        {
            System.Threading.Thread.Sleep(delayTime);
            var element = _driver.FindElementByAccessibilityId(automationId);
            return element.Location;
        }

        public string GetText(string automationId, int delayTime = DelayTime)
        {
            System.Threading.Thread.Sleep(delayTime);
            var element = _driver.FindElementByAccessibilityId(automationId);
            return element.Text;
        }

        public Size GetSize(string automationId)
        {
            var element = _driver.FindElementByAccessibilityId(automationId);
            return element.Size;
        }

        public void SetAttribute(string automationId, string attribute, object value, int delayTime = DelayTime)
        {
            var element = _driver.FindElementByAccessibilityId(automationId) as TizenElement;
            if (element != null)
            {
                element.SetAttribute(attribute, value.ToString());
                System.Threading.Thread.Sleep(delayTime);
            }
        }

        public void GetScreenshotAndSave(string imageName)
        {
            TizenDriver<AppiumWebElement> tizenDriver = _driver as TizenDriver<AppiumWebElement>;
            if (tizenDriver == null)
                return;

            var path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            var imagePath = path + "/images/" + imageName;

            Screenshot screenshot = tizenDriver.GetScreenshot();

            Image image = tizenDriver.TransformScreenshot(screenshot, new Rectangle(0, 35, 720, 1280 - 35));

            image.Save(imagePath);
        }

        public bool CompareToScreenshot(string imageName)
        {
            TizenDriver<AppiumWebElement> tizenDriver = _driver as TizenDriver<AppiumWebElement>;
            if (tizenDriver == null)
                return false;

            var path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            if (!File.Exists(path + "/temp"))
            {
                Directory.CreateDirectory(path + "/temp");
            }
            var tempImagePath = path + "/temp/temp.png";

            Screenshot screenshot = tizenDriver.GetScreenshot();

            Image image = tizenDriver.TransformScreenshot(screenshot, new Rectangle(0, 35, 720, 1280 - 35));
            image.Save(tempImagePath);

            var orgImage = Image.FromFile(path + "/images/" + imageName);
            var compareImage = Image.FromFile(tempImagePath);

            var result = tizenDriver.CompareImages(orgImage, compareImage);

            image.Dispose();
            compareImage.Dispose();

            File.Delete(tempImagePath);

            return result;
        }

        public void CheckScreenshot(string image)
        {
            //GetScreenshotAndSave(image);
            Assert.AreEqual(true, CompareToScreenshot(image));
        }
    }
}
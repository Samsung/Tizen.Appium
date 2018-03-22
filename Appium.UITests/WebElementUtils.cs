using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using System.Drawing;
using OpenQA.Selenium.Appium.Tizen;
using System.IO;
using OpenQA.Selenium;

namespace Appium.UITests
{
    public class WebElementUtils
    {
        public static AppiumWebElement GetWebElement(AppiumDriver driver, string automationId)
        {
            return driver.GetWebElement(automationId);
        }

        public static void Click(AppiumDriver driver, string automationId)
        {
            AppiumWebElement element = driver.GetWebElement(automationId);
            var touch = new RemoteTouchScreen(driver.Driver);
            int X = element.Location.X;
            int Y = element.Location.Y;
            touch.Down(X, Y);
            touch.Up(X, Y);
            System.Threading.Thread.Sleep(3000);
            return;
        }

        public static void ClickWithoutSleep(AppiumDriver driver, string automationId)
        {
            AppiumWebElement element = driver.GetWebElement(automationId);
            var touch = new RemoteTouchScreen(driver.Driver);
            int X = element.Location.X;
            int Y = element.Location.Y;
            touch.Down(X, Y);
            touch.Up(X, Y);
            return;
        }

        public static bool GetDisplayed(AppiumDriver driver, string automationId)
        {
            AppiumWebElement element = driver.GetWebElement(automationId);
            bool result = element.Displayed;
            return result;
        }

        public static Size GetSize(AppiumDriver driver, string automationId)
        {
            AppiumWebElement element = driver.GetWebElement(automationId);
            return element.Size;
        }

        public static void SetText(AppiumDriver driver, string automationId, string inputText)
        {
            //AppiumWebElement element = driver.GetWebElement(automationId);
            //element.SetImmediateValue(inputText);
            AppiumWebElement element = driver.GetWebElement(automationId);
            var touch = new RemoteTouchScreen(driver.Driver);
            int X = element.Location.X;
            int Y = element.Location.Y;
            touch.Down(X, Y);
            touch.Up(X, Y);
            driver.Driver.Keyboard.SendKeys(inputText);
            return;
        }

        public static void ClearText(AppiumDriver driver, string automationId)
        {
            AppiumWebElement element = driver.GetWebElement(automationId);
            element.Clear();
            return;
        }

        public static string GetText(AppiumDriver driver, string automationId)
        {
            System.Threading.Thread.Sleep(1000);
            AppiumWebElement element = driver.GetWebElement(automationId);
            return element.Text;
        }

        public static string GetAttribute(AppiumDriver driver, string automationId, string attribute)
        {
            System.Threading.Thread.Sleep(1000);
            AppiumWebElement element = driver.GetWebElement(automationId);
            return element.GetAttribute(attribute);
        }

        public static T GetAttribute<T>(AppiumDriver driver, string automationId, string attribute)
        {
            var stringValue = WebElementUtils.GetAttribute(driver, automationId, attribute);
            if (!String.IsNullOrEmpty(stringValue))
            {
                T value = (T)Convert.ChangeType(stringValue, typeof(T));
                return value;
            }

            return default(T);
        }

        public static void SetAttribute(AppiumDriver driver, string automationId, string attribute, object value)
        {
            TizenElement element = driver.GetWebElement(automationId) as TizenElement;
            if (element != null)
            {
                element.SetAttribute(attribute, value.ToString());
                System.Threading.Thread.Sleep(1000);
            }
        }

        public static bool GetEnabled(AppiumDriver driver, string automationId)
        {
            AppiumWebElement element = driver.GetWebElement(automationId);
            return element.Enabled;
        }

        public static Point GetLocation(AppiumDriver driver, string automationId)
        {
            AppiumWebElement element = driver.GetWebElement(automationId);
            return element.Location;
        }

        public static bool GetSelected(AppiumDriver driver, string automationId)
        {
            AppiumWebElement element = driver.GetWebElement(automationId);
            return element.Selected;
        }

        public static void GetScreenshotAndSave(AppiumDriver driver, string imageName)
        {
            TizenDriver<AppiumWebElement> tizenDriver = driver.Driver as TizenDriver<AppiumWebElement>;
            var path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            var imagePath = path + "/images/" + imageName;

            Screenshot screenshot = tizenDriver.GetScreenshot();

            Image image = tizenDriver.CropAndConvertImage(screenshot, new Rectangle(0, 35, 720, 1024 - 35));

            image.Save(imagePath);
        }

        public static bool CompareToScreenshot(AppiumDriver driver, string imageName)
        {
            TizenDriver<AppiumWebElement> tizenDriver = driver.Driver as TizenDriver<AppiumWebElement>;
            var path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            if (!File.Exists(path + "/temp"))
            {
                Directory.CreateDirectory(path + "/temp");
            }
            var tempImagePath = path + "/temp/temp.png";

            Screenshot screenshot = tizenDriver.GetScreenshot();

            Image image = tizenDriver.CropAndConvertImage(screenshot, new Rectangle(0, 35, 720, 1024 - 35));
            image.Save(tempImagePath);

            var orgImage = Image.FromFile(path + "/images/" + imageName);
            var compareImage = Image.FromFile(tempImagePath);

            var result = tizenDriver.CompareToImages(orgImage, compareImage);

            image.Dispose();
            compareImage.Dispose();

            File.Delete(tempImagePath);

            return result;
        }
    }
}

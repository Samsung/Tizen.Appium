using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions.Internal;
using System.Drawing;

namespace Appium.UITests
{
    public class RemoteTouchScreenUtils
    {
        RemoteTouchScreen TouchScreen = null;
        AppiumDriver Driver = null;

        public RemoteTouchScreenUtils(AppiumDriver driver)
        {
            Driver = driver;
            TouchScreen = new RemoteTouchScreen(driver.Driver);
        }

        public void Down(int x, int y)
        {
            TouchScreen.Down(x, y);
        }

        public void Up(int x, int y)
        {
            TouchScreen.Up(x, y);
            System.Threading.Thread.Sleep(1000);
        }

        public void Move(int x, int y)
        {
            TouchScreen.Move(x, y);
        }

        public void Drag(int startX, int startY, int endX, int endY, int delayTime)
        {
            TouchScreen.Down(startX, startY);
            System.Threading.Thread.Sleep(delayTime);
            TouchScreen.Move(endX, endX);
            System.Threading.Thread.Sleep(delayTime);
            TouchScreen.Up(endX, endX);
        }

        public void Drag(int startX, int startY, int endX, int endY)
        {
            var delayTime = 1000;
            Drag(startX, startY, endX, endY, delayTime);
        }

        public void Flick(int speedX, int speedY)
        {
            TouchScreen.Flick(speedX, speedY);
            System.Threading.Thread.Sleep(1000);
        }
    }
}

# Tizen.Appium
`Tizen.Appium` is a service library that supports running Appium for Tizen .NET applications. It can simulate user interactions on Tizen .NET applications (`ElmSharp`,`NUI`) and also cross platform `Xamarin.Forms` application. As its name implies, it works based on the [Appium](http://appium.io/) that is an open source test automation framework.

## Getting Started with Tizen.Appium

`Tizen.Appium` allows developers to write automated UI tests for Tizen .NET. 

#### Prepare Your Test Environment
This [link](https://github.com/Samsung/Tizen.Appium/wiki/How-to-use-appium) show how to setup the Appium.

#### Adding Tizen.Appium support to Tizen .NET apps
To automated your Tizen .NET applications, add `Tizen.Appium` as a pacakage referernce to your application project.
```xml
<PackageReference Include="Tizen.Appium" Version="1.0.0-preview" />
```
> ElmSharp and NUI applications require a [Tizen.NET package](https://tizen.myget.org/feed/dotnet/package/nuget/Tizen.NET) version 6.0 or higher.

> Xamarin.Forms application requires a [Tizen.NET 4.0.0](https://www.nuget.org/packages/Tizen.NET/4.0.0).

#### Initializing the Tizen.Appium

Add the following code to initialize `Tizen.Appium`. 

###### ElmSharp Application
```cs
using Tizen.Appium;

class App : CoreUIApplication
{
    protected override void OnCreate()
    {
        base.OnCreate();
#if UITEST
        TizenAppium.StartService(AppType.ElmSharp);
#endif
        //...
     }
     //...
}
```

###### NUI Application
```cs
using Tizen.Appium;

class Program : NUIApplication
{
    protected override void OnCreate()
    {
        base.OnCreate();
#if UITEST
        TizenAppium.StartService(AppType.NUI);
#endif
        //...
    }
    //...
}
```

###### Xamarin.Forms Application

```cs
using Tizen.Appium;

class Program : global::Xamarin.Forms.Platform.Tizen.FormsApplication
{
    protected override void OnCreate()
    {
        base.OnCreate();
#if UITEST
        TizenAppium.StartService();
#endif
        LoadApplication(new App());
        //...
    }
    //...
}
```

#### Set AutomationId in Test Application

`Tizen.Appium` automates the user interface by activating controls on the screen and performing input. To do this, you should assign a  unique identifier to each controls.
> Note that an exception will be thrown if an attempt is made to set the `AutomationId` property more than once.

###### ElmSharp Application
In ElmSharp, the recommended way to set this identifier is by using `AutomationId` property as shown below

```cs
var button = new Button(window)
{
    Text = "button",
    AutomationId = "button"
};
```

###### NUI Application
The true is same on NUI application. 

```cs
PushButton button = new PushButton
{
    LabelText = "Button",
    AutomationId = "button"
}
```

###### Xamarin.Forms Application
The true is same on Xamarin.Forms application. 

```cs
Button button = new Button
{
    Text = "Button",
    AutomationId = "button"
}
```

#### Writing Your Test Script
Visual Studio has a template to help add a Tizen .NET UI Test projenct to an existing your application solution:
> Upcoming [Visual Studio Tools for Tizen](https://marketplace.visualstudio.com/items?itemName=tizen.VisualStudioToolsforTizen) will support this template. Until then, you can manually create and use the UI test project

1. Right click on the solution, and select File > New Project

2. From the Tizen Templates, select the UI Test App template

###### How to manually create a UI Test project

1. Create a test project in Visual Studio.

2. Add `Appium.WebDriver` as a package reference to your project (*.csporj)
>Tizen driver is supported from `Appium.WebDriver 4.0.0.2-beta`. Therefore, we recommend that you use the version or later.
<img src="https://github.com/Samsung/Tizen.Appium/wiki/images/appium_webdriver_nuget.png">

3. Add the following code to initialize the `TizenDriver` and set the `AppiumOptions`
```cs
static void Main(string[] args)
{
    AppiumOptions appiumOptions = new AppiumOptions();
    appiumOptions.AddAdditionalCapability("platformName", "Tizen");
    appiumOptions.AddAdditionalCapability("deviceName", "emulator-26101");
    appiumOptions.AddAdditionalCapability("appPackage", "org.tizen.example.NUIApp");

    var driver = new TizenDriver<TizenElement>(new Uri("http://127.0.0.1:4723/wd/hub"), appiumOptions);
    ExecuteTest(driver);
}

static void ExecuteTest(TizenDriver<TizenElement> driver)
{
    driver.FindElementByAccessibilityId("Button").Click();
}
```
Make sure you set the appium server ip(ex:127.0.0.1:4723) and port number. You should set same server port number. (appium default port number is '4723').
> If you want to find a device name, use 'sdb devices' command. You can find device list and the name.

#### Running UI Automation Test

Right-click on your test, and select ‘Run Test’, or you can select the test in the Test Explorer. (WIP)

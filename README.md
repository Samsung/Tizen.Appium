# Tizen.Appium [![NuGet](https://img.shields.io/nuget/v/Tizen.Appium.svg?style=flat-square&label=Tizen.Appium)](https://www.nuget.org/packages/Tizen.Appium/) [![NuGet](https://img.shields.io/nuget/v/Tizen.Appium.Forms.svg?style=flat-square&label=Tizen.Appium.Forms)](https://www.nuget.org/packages/Tizen.Appium.Forms/)
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
In ElmSharp, the recommended way to set this identifier is by using `AutomationId` property as shown below.

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
> Upcoming [Visual Studio Tools for Tizen](https://marketplace.visualstudio.com/items?itemName=tizen.VisualStudioToolsforTizen) will support this template. Until then, you can manually create and use the UI test project.

1. Right click on the solution, and select File > New Project

2. From the Tizen Templates, select the UI Test App template

###### How to manually create a UI Test project

1. Create a test project in Visual Studio<br>
   Select Visual C# -> Test -> Nunit Test Project
   > If you know use to other test project, you can use it.
   
   ![image](https://user-images.githubusercontent.com/16184582/54807302-2cc43a00-4cc0-11e9-82fc-ebdbdff3d7ae.png)

2. Add `Appium.WebDriver` as a package reference to your project (*.csporj)
>Tizen driver is supported from `Appium.WebDriver 4.0.0.2-beta`. Therefore, we recommend that you use the version or later.
<img src="https://github.com/Samsung/Tizen.Appium/wiki/images/appium_webdriver_nuget.png">

3. Add the following code to initialize the `TizenDriver` and set the `AppiumOptions`
```cs
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
    }
}
```
Make sure you set the appium server ip(ex:127.0.0.1:4723) and port number. You should set same server port number. (appium default port number is '4723')
> If you want to find a device name, use 'sdb devices' command. You can find device list and the name.

4. Install Nunit3 Test Adapter<br>
   Go to Tools -> Extesion and Updates -> Select Online -> Search 'Nunit 3 Test Adapter'
   ![image](https://user-images.githubusercontent.com/16184582/54807753-94c75000-4cc1-11e9-9f3d-20f6f41b3d73.png)
   
5. Open Test Explorer<br>
   Go to Test -> Windows -> Test Explorer<br>
   ![image](https://user-images.githubusercontent.com/16184582/54807946-1fa84a80-4cc2-11e9-8fd8-1352f8018c96.png)

#### Running UI Automation Test

Right-click on your test, and select ‘Run Test’.<br>
![image](https://user-images.githubusercontent.com/16184582/54808076-6c8c2100-4cc2-11e9-983d-eccc517c748c.png)

If the test is successful.<br>
![image](https://user-images.githubusercontent.com/16184582/54808182-ca206d80-4cc2-11e9-8f37-117a867a8646.png)

If the test is fails, you can determine the cause.<br>
![image](https://user-images.githubusercontent.com/16184582/54808277-1bc8f800-4cc3-11e9-957e-54f1d00bf4bd.png)

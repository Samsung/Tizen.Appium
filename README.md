# Tizen.Appium
`Tizen.Appium` is a service library that supports running Appium for Tizen applications.
Three types of the UI framework including `ElmSharp`, `NUI`, and `Xamarin.Forms` are supported.

## How to use
- Prepare a Tizen application to do the UI automation test (Appium).

- Add `Tizen.Appium` library as a reference on the application project.

- Add initialize code like followings based on the UI framework type of the application.</br>Add `TizenAppium.StartService();` under `OnCreate()` method.

### Xamarin.Forms
```c#
using Tizen.Appium;

class Program : global::Xamarin.Forms.Platform.Tizen.FormsApplication
{
    protected override void OnCreate()
    {
        base.OnCreate();
        TizenAppium.StartService();
        LoadApplication(new App());
    }

    static void Main(string[] args)
    {
        var app = new Program();
        global::Xamarin.Forms.Platform.Tizen.Forms.Init(app);
        app.Run(args);
    }
}
```

### ElmSharp
 - Tizen.NET 6.0 (nuget) or above is required.
```c#
using Tizen.Appium;

class App : CoreUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            TizenAppium.StartService();
            Initialize();
        }

        void Initialize()
        {
			// Your UI code is here.
        }

        static void Main(string[] args)
        {
            Elementary.Initialize();
            Elementary.ThemeOverlay();
            App app = new App();
            app.Run(args);
        }
```
### NUI
 - Tizen.NET 6.0 (nuget) or above is required.
```c#
using Tizen.Appium;

class Program : NUIApplication
{
    protected override void OnCreate()
    {
        base.OnCreate();
        TizenAppium.StartService(AppType.NUI); // `AppType.NUI` is required.
        Initialize();
    }

    void Initialize()
    {
		// Your UI code is here.
    }

    static void Main(string[] args)
    {
        var app = new Program();
        app.Run(args);
    }
}
```

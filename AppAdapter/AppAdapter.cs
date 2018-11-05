using System;
using Tizen.Applications;
using Xamarin.Forms.Platform.Tizen;
using Tizen.NUI;

namespace Tizen.Appium
{
    public class AppAdapter
    {
        public static IAppAdapter Create(CoreApplication application)
        {
            if (application is Xamarin.Forms.Platform.Tizen.FormsApplication)
                return new FormsAdapter();
            else if (application is NUIApplication nuiApp)
                return new NUIAdapter(nuiApp);
            else
                return new ElmSharpAdapter();
        }
    }
}
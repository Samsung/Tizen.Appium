using System;
using Tizen.Applications;
using Xamarin.Forms.Platform.Tizen;

namespace Tizen.Appium
{
    public class AppAdapter
    {
        public static IAppAdapter Create(CoreApplication application)
        {
            if (application is Xamarin.Forms.Platform.Tizen.FormsApplication formsApp)
                return new FormsAdapter(formsApp);
            else
                return new ElmSharpAdapter();
        }
    }
}
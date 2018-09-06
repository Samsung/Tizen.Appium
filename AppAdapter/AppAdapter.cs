using System;

namespace Tizen.Appium
{
    public enum AppType
    {
        Forms,
        ElmSharp
    }

    public class AppAdapter
    {
        public static IAppAdapter Create(AppType type)
        {
            switch (type)
            {
                case AppType.Forms:
                    return new FormsAdapter();
                case AppType.ElmSharp:
                    return new ElmSharpAdapter();
                default:
                    return null;
            }
        }
    }
}
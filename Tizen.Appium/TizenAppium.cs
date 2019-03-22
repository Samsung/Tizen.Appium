namespace Tizen.Appium
{
    public enum AppType
    {
        ElmSharp,
        NUI,
    }

    public partial class TizenAppium
    {
        public static void StartService(AppType type)
        {
            if (type == AppType.ElmSharp)
            {
                ElmSharpAdapter.Initialize();
            }
            else
            {
                NUIAdapter.Initialize();
            }
        }

        public static void StopService()
        {
            Stop();
        }
    }
}

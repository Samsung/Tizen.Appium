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
#if !__TIZEN4_0__
            if (type == AppType.ElmSharp)
            {
                ElmSharpAdapter.Initialize();
            }
            else
            {
                NUIAdapter.Initialize();
            }
#else
            throw new global::System.NotSupportedException("Use StartService(IAppAdapter adapter) instead on tizen40 TFM.");
#endif
        }

        public static void StartService(IAppAdapter adapter)
        {
            Start(adapter);
        }

        public static void StopService()
        {
            Stop();
        }
    }
}

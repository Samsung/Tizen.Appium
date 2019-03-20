namespace Tizen.Appium
{
    public partial class TizenAppium
    {
        public static void StartService(AppType type = AppType.ElmSharp)
        {
            if (type != AppType.NUI)
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

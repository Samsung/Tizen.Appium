using Tizen.Applications;

namespace Tizen.Appium
{
    public class TizenAppium
    {
        public static bool IsInitialized { get; private set; }

        public static readonly string Tag = "TizenAppium";

        public static void StartService(CoreApplication application)
        {
            Log.Debug("Start Service : initialize");

            if (IsInitialized)
                return;

            Server.Instance.Start(application);

            IsInitialized = true;
        }

        public static void StopService()
        {
            Log.Debug("StopService");

            if (IsInitialized)
            {
                Server.Instance.Stop();

                IsInitialized = false;
            }
        }
    }
}
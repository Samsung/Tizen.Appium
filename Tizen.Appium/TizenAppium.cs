namespace Tizen.Appium
{
    public class TizenAppium
    {
        public static bool IsInitialized { get; private set; }

        public static readonly string Tag = "TizenAppium";

        static TizenAppiumElement _elementManager;
        static TizenAppiumServer _server;

        public static void StartService(Xamarin.Forms.Application app = null)
        {
            Log.Debug("StartService : initialize");

            if (IsInitialized)
                return;

            _server = new TizenAppiumServer();
            _elementManager = new TizenAppiumElement(app);

            IsInitialized = true;
        }

        public static void StopService()
        {
            Log.Debug("StopService");

            _server.Stop();

            IsInitialized = false;
        }
    }
}
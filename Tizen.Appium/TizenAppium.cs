namespace Tizen.Appium
{
    public class TizenAppium
    {
        public static bool IsInitialized { get; private set; }

        public static readonly string Tag = "TizenAppium";

        static TizenAppiumDbus _dbus;
        static TizenAppiumElement _elementManager;

        public static void Init()
        {
            if (IsInitialized)
                return;

            IsInitialized = true;
        }

        public static void StartService(Xamarin.Forms.Application app = null)
        {
            Log.Debug("StartService : initialize dbus");

            if (IsInitialized)
                return;

            _dbus = new TizenAppiumDbus();
            _elementManager = new TizenAppiumElement(app);

            IsInitialized = true;
        }

        public static void StopService()
        {
            Log.Debug("StopService");
            _dbus.Dispose();
            IsInitialized = false;
        }
    }
}
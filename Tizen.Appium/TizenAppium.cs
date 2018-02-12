using System;

namespace Tizen.Appium
{
    public class TizenAppium
    {
        public static bool IsInitialized { get; private set; }

        public static readonly string Tag = "TizenAppium";

        static TizenAppiumDbus _dbus;

        public static void Init()
        {
            if (IsInitialized)
                return;

            IsInitialized = true;
        }

        public static void StartService()
        {
            Log.Debug(TizenAppium.Tag, "StartService : initialize dbus");
            if (IsInitialized)
                return;

            _dbus = new TizenAppiumDbus();

            IsInitialized = true;
        }

        public static void StopService()
        {
            Log.Debug(TizenAppium.Tag, "StopService");
            _dbus.Dispose();
            IsInitialized = false;
        }
    }
}
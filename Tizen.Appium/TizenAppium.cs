using System;

namespace Tizen.Appium
{
    public class TizenAppium
    {
        public static bool IsInitialized { get; private set; }

        static TizenAppiumDbus _dbus;

        public static void Init()
        {
            if (IsInitialized)
                return;

            IsInitialized = true;
        }

        public static void StartService()
        {
            Console.WriteLine("#### StartService : initialize dbus 22222");
            if (IsInitialized)
                return;

            _dbus = new TizenAppiumDbus();

            IsInitialized = true;
        }

        public static void StopService()
        {
            Console.WriteLine("#### StopService");
            _dbus.Dispose();
            IsInitialized = false;
        }
    }
}
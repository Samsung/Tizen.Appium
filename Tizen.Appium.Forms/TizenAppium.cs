using System;
using ElmSharp;
using Tizen.Applications;

namespace Tizen.Appium
{
    public partial class TizenAppium
    {
        public static void StartService()
        {
            Start(new FormsAdapter());
        }

        public static void StopService()
        {
            Stop();
        }
    }
}
using System;
using ElmSharp;
using Tizen.Appium;

namespace Tizen.Appium
{
    public sealed class ElmSharpAdapter : BaseAdapter
    {
        static bool _isInitialized = false;

        public static int ScreenWidth { get; private set; }
        public static int ScreenHeight { get; private set; }

        public static void Initialize()
        {
            if (!_isInitialized)
            {
                ScreenWidth = Utils.GetScreeenWidth();
                ScreenHeight = Utils.GetScreenHeight();

                TizenAppium.Start(new ElmSharpAdapter());
                _isInitialized = true;
            }
        }

        public static void Terminate()
        {
            if (_isInitialized)
            {
                TizenAppium.Stop();
                _isInitialized = false;
            }
        }

        protected override IObjectList CreateObjectList()
        {
            return new EvasObjectList();
        }

        protected override void AdaptApp()
        {
            Elementary.EvasObjectRealized += (s, e) =>
            {
                ObjectList.Add(s);
            };
            Elementary.ItemObjectRealized += (s, e) =>
            {
                ObjectList.Add(s);
            };
        }
    }
}

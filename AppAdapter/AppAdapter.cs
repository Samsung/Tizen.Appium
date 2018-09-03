using System;

namespace Tizen.Appium
{
    public abstract class AppAdapter
    {       
        public IObjectList ObjectList { get; private set; }

        static AppAdapter _adapter;

        public static AppAdapter Instance
        {
            get
            {
                if (_adapter == null)
                    Log.Debug("Call AppAdapter.Init(AppType) before using");

                return _adapter;
            }
        }

        protected AppAdapter()
        {
            ObjectList = InitObjectList();
        }

        public static void Init(AppType type)
        {
            if (type == AppType.Forms)
                _adapter = new FormsAdapter();
            else if (type == AppType.ElmSharp)
                _adapter = new ElmSharpAdapter();
            else
                Log.Debug("Notsupported type");
        }

        protected abstract IObjectList InitObjectList();

    }
}
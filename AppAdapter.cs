namespace Tizen.Appium
{
    public class AppAdapter
    {
        static BaseAdapter _adapter;

        public static IObjectList ObjectList
        {
            get
            {
                if (_adapter == null)
                    Log.Debug("Call AppAdapter.Init(AppType) before using");

                return _adapter.ObjectList;
            }
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
    }
}
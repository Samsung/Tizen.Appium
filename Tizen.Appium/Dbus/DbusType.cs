namespace Tizen.Appium.DBus
{
    public class DBusArgsType
    {
        public static readonly int Int = ((int)'i');
        public static readonly int String = ((int)'s');
    }

    public class DbusNames
    {
        public static readonly string BusName = "org.tizen.appium";
        public static readonly string ObjectPath = "/org/tizen/appium";
        public static readonly string InterfaceName = "org.tizen.appium";

        public static readonly string TestMethod = "Test";
        public static readonly string GetPositionMethod = "GetPosition";
        public static readonly string SetCommandMethod = "SetCommand";

        public static readonly string TestSignal = "TestSignal";
        public static readonly string CompleteSignal = "Complete";
    }
}

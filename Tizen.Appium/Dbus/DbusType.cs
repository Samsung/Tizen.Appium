namespace Tizen.Appium.DBus
{
    public class DBusArgsType
    {
        public static readonly int Int = ((int)'i');
        public static readonly int String = ((int)'s');
    }

    public class DBus
    {
        public static readonly string BusName = "org.tizen.appium";
        public static readonly string ObjectPath = "/org/tizen/appium";
        public static readonly string Interface = "org.tizen.appium";

        //Methods
        public static readonly string TestMethod = "Test";

        public static readonly string GetMethod = "Get";
        public static readonly string SetMethod = "SetCommand";

        //Signal
        public static readonly string TestSignal = "TestSignal";

        public static readonly string CompleteSignal = "Complete";
    }

    public class RequestInfo
    {
        public string RequestId { get; private set; }
        public string AutomationId { get; private set; }

        public string Command { get; private set; }

        public string Data { get; set; }

        public RequestInfo(string requestId = "", string automationId = "", string command = "")
        {
            RequestId = requestId;
            AutomationId = automationId;
            Command = command;
        }
    }
}

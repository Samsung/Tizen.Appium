namespace Tizen.Appium.Dbus
{
    public class DbusType
    {
        public static readonly int Int = ((int)'i');
        public static readonly int String = ((int)'s');
        public static readonly int Boolean = ((int)'b');
        public static readonly int Array = ((int)'a');
    }

    public class DbusTypeAsString
    {
        public static readonly char Int = 'i';
        public static readonly char String = 's';
        public static readonly char Boolean = 'b';
        public static readonly char Array = 'a';
    }

    public class Names
    {
        public static readonly string BusName = "org.tizen.appium";
        public static readonly string ObjectPath = "/org/tizen/appium";
        public static readonly string InterfaceName = "org.tizen.appium";
    }

    public class Methods
    {
        public static readonly string GetCenterX = "GetCenterX";
        public static readonly string GetCenterY = "GetCenterY";
        public static readonly string GetX = "GetX";
        public static readonly string GetY = "GetY";
        public static readonly string GetWidth = "GetWidth";
        public static readonly string GetHeight = "GetHeight";
        public static readonly string GetText = "GetText";
        public static readonly string GetProperty = "GetProperty";
        public static readonly string SubscribeEvent = "SubscribeEvent";
        public static readonly string UnsubscribeEvent = "UnsubscribeEvent";
    }

    public class Signals
    {
        public static readonly string Event = "Event";
    }

    public class Params
    {
        public static readonly string ElementId = "elementId";
        public static readonly string PropertyName = "propertyName";
        public static readonly string EventName = "eventName";
        public static readonly string SubscriptionId = "subscriptionId";
        public static readonly string Once = "once";
        public static readonly string Return = "return";
    }
}

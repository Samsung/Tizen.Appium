using System;

namespace Tizen.Appium.Dbus
{
    public class SubscribeEventMethod : IDbusMethod
    {
        public string Name => Dbus.Methods.SubscribeEvent;

        public string Signature => "sssb";

        public string ReturnSignature => "b";

        public string[] Params => new string[] {
            Dbus.Params.ElementId, Dbus.Params.EventName, Dbus.Params.SubscriptionId, Dbus.Params.Once };

        public Arguments Run(Arguments args)
        {
            Console.WriteLine("#### SubscribeEvent");

            var elementId = (string)args[Dbus.Params.ElementId];
            var eventName = (string)args[Dbus.Params.EventName];
            var id = (string)args[Dbus.Params.SubscriptionId];
            var once = (bool)args[Dbus.Params.Once];
            var ret = new Arguments();

            Console.WriteLine("#### elementId:{0}, eventName:{1}, id:{2}, once:{3}", elementId, eventName, id, once);

            var evtObj = EventObject.CreateEventObject(id, elementId, eventName, once, () =>
            {
                TizenAppiumDbus.DbusConnection.BroadcaseSignal(Signals.Event, args, "sss");
            });

            if (evtObj == null)
            {
                Console.WriteLine("#### Not available ID:{0}. it is already used for other event.", id);
                ret.SetArgument(Dbus.Params.Return, false);
            }
            else
            {
                var retVal = evtObj.Subscribe();
                ret.SetArgument(Dbus.Params.Return, retVal);
            }

            return ret;
        }
    }
}

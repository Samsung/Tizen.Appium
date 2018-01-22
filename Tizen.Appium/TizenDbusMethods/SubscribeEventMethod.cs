using System;
using Tizen;

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
            Log.Debug(TizenAppium.Tag,"#### SubscribeEvent");

            var elementId = (string)args[Dbus.Params.ElementId];
            var eventName = (string)args[Dbus.Params.EventName];
            var id = (string)args[Dbus.Params.SubscriptionId];
            var once = (bool)args[Dbus.Params.Once];
            var ret = new Arguments();

            Log.Debug(TizenAppium.Tag,"#### elementId:"+ elementId+", eventName:"+ eventName + ", id:"+id+", once:"+once);

            var evtObj = EventObject.CreateEventObject(id, elementId, eventName, once, () =>
            {
                TizenAppiumDbus.DbusConnection.BroadcaseSignal(Signals.Event, args, "sss");
            });

            if (evtObj == null)
            {
                Log.Debug(TizenAppium.Tag,"#### Not available ID:"+id+". it is already used for other event.");
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

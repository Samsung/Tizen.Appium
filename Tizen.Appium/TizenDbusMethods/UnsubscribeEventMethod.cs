using System;

namespace Tizen.Appium.Dbus
{
    public class UnsubscribeEventMethod : IDbusMethod
    {
        public string Name => Dbus.Methods.UnsubscribeEvent;

        public string Signature => "s";

        public string ReturnSignature => "b";

        public string[] Params => new string[] { Dbus.Params.SubscriptionId };

        public Arguments Run(Arguments args)
        {
            Log.Debug(TizenAppium.Tag,"#### Unsubscribe");

            var id = (string)args[Dbus.Params.SubscriptionId];
            var ret = new Arguments();

            var evtObj = EventObject.GetEventObject(id);

            if (evtObj == null)
            {
                Log.Debug(TizenAppium.Tag,"#### Not available ID:"+id+". There is no subscriber for this id.");
                ret.SetArgument(Dbus.Params.Return, false);
            }
            else
            {
                var retVal = evtObj?.Unsubscribe();
                ret.SetArgument(Dbus.Params.Return, retVal);
            }

            return ret;
        }
    }
}

using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;

namespace Tizen.Appium.Dbus
{
    public class GetCenterXMethod : IDbusMethod
    {
        public string Name => Dbus.Methods.GetCenterX;

        public string Signature => "s";

        public string ReturnSignature => "i";

        public string[] Params => new string[] { Dbus.Params.ElementId };

        public Arguments Run(Arguments args)
        {
            Log.Debug(TizenAppium.Tag,"#### GetCenterX");

            var elementId = (string)args[Dbus.Params.ElementId];
            var ret = new Arguments();

            var ve = ElementUtils.GetTestableElement(elementId) as VisualElement;
            if (ve == null)
            {
                Log.Debug(TizenAppium.Tag,"#### Not Found Element");
                ret.SetArgument(Dbus.Params.Return, -1);
                return ret;
            }

            var nativeView = Platform.GetOrCreateRenderer(ve).NativeView;
            var x = nativeView.Geometry.X + (nativeView.Geometry.Width / 2);

            ret.SetArgument(Dbus.Params.Return, x);

            return ret;
        }
    }
}

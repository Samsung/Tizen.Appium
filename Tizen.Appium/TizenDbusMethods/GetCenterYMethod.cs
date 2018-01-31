using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Tizen.Appium.Dbus;
using ElmSharp;

namespace Tizen.Appium
{
    public class GetCenterYMethod : IDbusMethod
    {
        public string Name => MethodNames.GetCenterY;

        public string Signature => "s";

        public string ReturnSignature => "i";

        public string[] Args => new string[] { Params.ElementId };

        public Arguments Run(Arguments args)
        {
            Log.Debug(TizenAppium.Tag, "##### GetCenterY");

            var elementId = (string)args[Params.ElementId];
            var ret = new Arguments();

            var ve = ElementUtils.GetTestableElement(elementId) as VisualElement;
            if (ve != null)
            {
                var nativeView = Platform.GetOrCreateRenderer(ve).NativeView;
                var y = nativeView.Geometry.Y + (nativeView.Geometry.Height / 2);
                ret.SetArgument(Params.Return, y);
                return ret;
            }

            var item = ElementUtils.GetTestableElement(elementId) as ItemObject;
            if (item != null)
            {
                var y = item.TrackObject.Geometry.Y + (item.TrackObject.Geometry.Height / 2);
                ret.SetArgument(Params.Return, y);
                return ret;
            }

            Log.Debug(TizenAppium.Tag, "#### Not Found Element");
            ret.SetArgument(Params.Return, -1);
            return ret;
        }
    }
}

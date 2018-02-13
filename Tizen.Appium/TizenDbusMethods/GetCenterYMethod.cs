using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Tizen.Appium.Dbus;
using ElmSharp;
using System;
using TSystemInfo = Tizen.System.Information;

namespace Tizen.Appium
{
    public class GetCenterYMethod : IDbusMethod
    {
        public string Name => MethodNames.GetCenterY;

        public string Signature => "s";

        public string ReturnSignature => "i";

        public string[] Args => new string[] { Params.ElementId };

        //The element should be shown bigger than Minimun size for testing.
        int MinisumSize = 2;

        public Arguments Run(Arguments args)
        {
            Log.Debug(TizenAppium.Tag, "GetCenterY");

            var elementId = (string)args[Params.ElementId];
            var ret = new Arguments();

            var element = ElementUtils.GetTestableElement(elementId);
            if (element == null)
            {
                Log.Debug(TizenAppium.Tag, "Not Found Element");
                ret.SetArgument(Params.Return, -1);
                return ret;
            }

            EvasObject nativeView;
            if (element is VisualElement)
            {
                nativeView = Platform.GetOrCreateRenderer(element as VisualElement).NativeView;
            }
            else
            {
                nativeView = (element as ItemObject).TrackObject;
            }
            ret.SetArgument(Params.Return, GetCenterY(nativeView));
            return ret;
        }

        int GetCenterY(EvasObject obj)
        {
            int screenHeight;
            TSystemInfo.TryGetValue("http://tizen.org/feature/screen.height", out screenHeight);

            if ((obj.Geometry.Y > screenHeight) || (obj.Geometry.Y + obj.Geometry.Height) < 0)
            {
                return -1;
            }

            var x1 = Math.Max(0, obj.Geometry.Y);
            var x2 = Math.Min(screenHeight, obj.Geometry.Y + obj.Geometry.Height);

            if ((x2 - x1) < MinisumSize)
            {
                return -1;
            }
            else
            {
                return (int)((x1 + x2) / 2);
            }
        }
    }
}

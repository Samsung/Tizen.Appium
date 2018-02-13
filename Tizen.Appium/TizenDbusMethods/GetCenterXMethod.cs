using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Tizen.Appium.Dbus;
using ElmSharp;
using System;
using TSystemInfo = Tizen.System.Information;

namespace Tizen.Appium
{
    public class GetCenterXMethod : IDbusMethod
    {
        public string Name => MethodNames.GetCenterX;

        public string Signature => "s";

        public string ReturnSignature => "i";

        public string[] Args => new string[] { Params.ElementId };

        //The element should be shown bigger than Minimun size for testing.
        int MinisumSize = 2;

        public Arguments Run(Arguments args)
        {
            Log.Debug(TizenAppium.Tag, "GetCenterX");

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
            ret.SetArgument(Params.Return, GetCenterX(nativeView));
            return ret;
        }

        int GetCenterX(EvasObject obj)
        {
            int screenWidth;
            TSystemInfo.TryGetValue("http://tizen.org/feature/screen.width", out screenWidth);

            if ((obj.Geometry.X > screenWidth) || (obj.Geometry.X + obj.Geometry.Width) < 0)
            {
                return -1;
            }

            var x1 = Math.Max(0, obj.Geometry.X);
            var x2 = Math.Min(screenWidth, obj.Geometry.X + obj.Geometry.Width);

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

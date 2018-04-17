using System;
using ElmSharp;
using TSystemInfo = Tizen.System.Information;

namespace Tizen.Appium
{
    internal class GetLocationCommand : ICommand
    {
        //The element should be shown bigger than Minimun size for testing.
        int MinisumSize = 2;

        public string Command => Commands.GetLocation;

        public Result Run(Request req)
        {
            Log.Debug("Run: GetLocation");

            var elementId = req.Params.ElementId;

            var result = new Result();

            var nativeView = ElementUtils.GetElementWrapper(elementId)?.NativeView;
            if (nativeView == null)
            {
                Log.Debug("Not Found Element");
                result.Value = new Location(); ;
                return result;
            }

            result.Value = new Location(nativeView.Geometry.X, nativeView.Geometry.Y, GetCenterX(nativeView), GetCenterY(nativeView));

            return result;
        }

        int GetCenterX(EvasObject obj)
        {
            if (obj == null)
                return -1;

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

        int GetCenterY(EvasObject obj)
        {
            if (obj == null)
                return -1;

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

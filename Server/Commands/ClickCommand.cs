using System;
using TSystemInfo = Tizen.System.Information;

namespace Tizen.Appium
{
    public class ClickCommand : ICommand
    {
        int MinisumSize = 2;

        public string Command => Commands.Click;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            var elementId = req.Params.ElementId;
            var result = new Result();

            var location = objectList.GetLocation(elementId);
            var x = GetCenterX(location);
            var y = GetCenterY(location);

            result.Value = inputGen.Click(x, y);
            return result;
        }

        int GetCenterX(Location location)
        {
            int screenWidth;
            TSystemInfo.TryGetValue("http://tizen.org/feature/screen.width", out screenWidth);

            if ((location.X > screenWidth) || (location.X + location.Width) < 0)
            {
                return -1;
            }

            var x1 = Math.Max(0, location.X);
            var x2 = Math.Min(screenWidth, location.X + location.Width);

            if ((x2 - x1) < MinisumSize)
            {
                return -1;
            }
            else
            {
                return (int)((x1 + x2) / 2);
            }
        }

        int GetCenterY(Location location)
        {
            int screenHeight;
            TSystemInfo.TryGetValue("http://tizen.org/feature/screen.height", out screenHeight);

            if ((location.Y > screenHeight) || (location.Y + location.Height) < 0)
            {
                return -1;
            }

            var x1 = Math.Max(0, location.Y);
            var x2 = Math.Min(screenHeight, location.Y + location.Height);

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
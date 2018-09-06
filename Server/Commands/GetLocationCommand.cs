using System;
using TSystemInfo = Tizen.System.Information;

namespace Tizen.Appium
{
    // TODO : This command will be deprecated
    public class GetLocationCommand : ICommand
    {
        //The element should be shown bigger than Minimun size for testing.
        int MinisumSize = 2;

        public string Command => Commands.GetLocation;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            Log.Debug("Run: GetLocation");

            var elementId = req.Params.ElementId;
            var result = new Result();
            var location = objectList.GetLocation(elementId);

            //fixed with screen size 
            result.Value = new Location(location.X, location.Y, GetCenterX(location), GetCenterY(location), location.Width, location.Height);

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

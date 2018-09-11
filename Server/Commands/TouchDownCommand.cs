using System;

namespace Tizen.Appium
{
    public class TouchDownCommand : ICommand
    {
        public string Command => Commands.TouchDown;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            var elementId = req.Params.ElementId;
            int x = req.Params.X;
            int y = req.Params.Y;
            var result = new Result();
            
            if (String.IsNullOrEmpty(elementId))
            {
                var geometry = objectList.GetGeometry(elementId);
                result.Value = inputGen.TouchDown(geometry.CenterX, geometry.CenterY);
            }
            else if ( (x > 0) && (y > 0))
            {
                result.Value = inputGen.TouchDown(x, y);
            }
            else
            {
                Log.Debug("Invalid values");
            }
            
            return result;
        }
    }
}
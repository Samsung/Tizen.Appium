using System;

namespace Tizen.Appium
{
    public class TouchUpCommand : ICommand
    {
        public string Command => Commands.TouchUp;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            var elementId = req.Params.ElementId;
            var x = req.Params.X;
            var y = req.Params.Y;
            var result = new Result();
            
            if (String.IsNullOrEmpty(elementId))
            {
                var geometry = objectList.GetGeometry(elementId);
                result.Value = inputGen.TouchUp(geometry.CenterX, geometry.CenterY);
            }
            else if ( (x > 0) && (y > 0))
            {
                result.Value = inputGen.TouchUp(x, y);
            }
            else
            {
                Log.Debug("Invalid values");
            }
            
            return result;
        }
    }
}
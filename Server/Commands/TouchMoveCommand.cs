using System;

namespace Tizen.Appium
{
    public class TouchMoveCommand : ICommand
    {
        public string Command => Commands.TouchMove;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            var elementId = req.Params.ElementId;
            var x = req.Params.X;
            var y = req.Params.Y;
            var result = new Result();
            
            if (String.IsNullOrEmpty(elementId))
            {
                var geometry = objectList.GetGeometry(elementId);
                result.Value = inputGen.TouchMove(geometry.CenterX, geometry.CenterY);
            }
            else if ( (x > 0) && (y > 0))
            {
                result.Value = inputGen.TouchMove(x, y);
            }
            else
            {
                Log.Debug("Invalid values");
            }
            
            return result;
        }
    }
}
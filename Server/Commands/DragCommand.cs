using System;

namespace Tizen.Appium
{
    public class DragCommand : ICommand
    {
        public string Command => Commands.Drag;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            Log.Debug("Run: Drag");

            var elementId = req.Params.ElementId;
            var xSpeed = req.Params.XSpeed;
            var ySpeed = req.Params.YSpeed;
            var result = new Result();

            var geometry = objectList.GetGeometry(elementId);
            var x = geometry.CenterX;
            var y = geometry.CenterY;

            result.Value = inputGen.Drag(x, y, x + xSpeed, y + ySpeed);

            return result;
        }
    }
}
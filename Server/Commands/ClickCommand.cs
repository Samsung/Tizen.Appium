using System;

namespace Tizen.Appium
{
    public class ClickCommand : ICommand
    {
        public string Command => Commands.Click;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            Log.Debug("Run: Click");

            var elementId = req.Params.ElementId;
            var result = new Result();

            var geometry = objectList.GetGeometry(elementId);
            result.Value = inputGen.Click(geometry.CenterX, geometry.CenterY);

            return result;
        }
    }
}
using System;

namespace Tizen.Appium
{
    public class FlickCommand : ICommand
    {
        public string Command => Commands.Flick;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            var xSpeed = req.Params.XSpeed;
            var ySpeed = req.Params.YSpeed;
            var x = Utils.GetScreeenWidth() / 2;
            var y = Utils.GetScreenHeight() / 2;

            var result = new Result();
            result.Value = inputGen.Drag(x, y, x + xSpeed, y + ySpeed);

            return result;
        }
    }
}
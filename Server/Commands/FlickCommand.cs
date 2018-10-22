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
            try
            {
                result.Value = inputGen.Drag(x, y, x + xSpeed, y + ySpeed);
            }
            catch (TimeoutException te)
            {
                Log.Debug(te.ToString());
                result.Status = 44;
                result.Value = false;
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
                result.Value = false;
            }

            return result;
        }
    }
}
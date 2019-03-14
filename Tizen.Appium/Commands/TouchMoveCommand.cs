using System;

namespace Tizen.Appium
{
    public class TouchMoveCommand : ICommand
    {
        public string Command => Commands.TouchMove;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {

            Log.Debug("Run: TouchMove");
            var elementId = req.Params.ElementId;
            var xDown = req.Params.XDown;
            var yDown = req.Params.YDown;
            var xUp = req.Params.XUp;
            var yUp = req.Params.YUp;
            var steps = req.Params.Steps;
            var result = new Result();

            try
            {
                if (!String.IsNullOrEmpty(elementId))
                {
                    var geometry = objectList.Get(elementId).Geometry;
                    result.Value = inputGen.TouchMove(geometry.CenterX, geometry.CenterY, xUp, yUp, steps);
                }
                else if ((xDown > 0) && (yDown > 0) && (xUp > 0) && (yUp > 0))
                {
                    result.Value = inputGen.TouchMove(xDown, yDown, xUp, yUp, steps);
                }
                else
                {
                    Log.Debug("Invalid values");
                }
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
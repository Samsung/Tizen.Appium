using System;

namespace Tizen.Appium
{
    public class TouchDownCommand : ICommand
    {
        public string Command => Commands.TouchDown;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            Log.Debug("Run: TouchDown");

            var elementId = req.Params.ElementId;
            int x = req.Params.X;
            int y = req.Params.Y;
            var result = new Result();
            
            try
            {
                if (!String.IsNullOrEmpty(elementId))
                {
                    var geometry = objectList.Get(elementId)?.Geometry;
                    result.Value = inputGen.TouchDown(geometry.CenterX, geometry.CenterY);
                }
                else if ((x > 0) && (y > 0))
                {
                    result.Value = inputGen.TouchDown(x, y);
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
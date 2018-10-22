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

            try
            {
                var geometry = objectList.Get(elementId)?.Geometry;
                result.Value = inputGen.Click(geometry.CenterX, geometry.CenterY);
            }
            catch(TimeoutException te)
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
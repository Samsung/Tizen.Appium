using System;

namespace Tizen.Appium
{
    internal class ReleaseKeyCommand : ICommand
    {
        public string Command => Commands.ReleaseKey;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            var key = req.Params.Key;
            var result = new Result();

            try
            {
                result.Value = inputGen.ReleaseKey(key);
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
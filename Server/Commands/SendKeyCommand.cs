using System;

namespace Tizen.Appium
{
    internal class SendKeyCommand : ICommand
    {
        public string Command => Commands.SendKey;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            var key = req.Params.Key;
            var result = new Result();

            try
            {
                result.Value = inputGen.SendKey(key);
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
using System;

namespace Tizen.Appium
{
    internal class SendKeysCommand : ICommand
    {
        public string Command => Commands.SendKeys;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            var keys = req.Params.Keys;
            var result = new Result();

            try
            {
                result.Value = inputGen.SendKeys(keys);
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
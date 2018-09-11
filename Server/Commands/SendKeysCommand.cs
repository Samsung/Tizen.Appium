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

            result.Value = inputGen.SendKeys(keys).ToString().ToLower();
            return result;
        }
    }
}
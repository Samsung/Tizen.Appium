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

            result.Value = inputGen.SendKey(key).ToString().ToLower();
            return result;
        }
    }
}
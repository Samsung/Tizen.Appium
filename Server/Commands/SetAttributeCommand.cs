using System;

namespace Tizen.Appium
{
    public class SetAttributeCommand : ICommand
    {
        public string Command => Commands.SetAttribute;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            Log.Debug("Run: SetAttribute");

            var elementId = req.Params.ElementId;
            var propertyName = req.Params.Attribute;
            var newValue = req.Params.Value;
            var result = new Result();

            var ret = objectList.Get(elementId)?.SetPropertyValue(propertyName, newValue);
            if(ret == true)
            {
                result.Value = ret;
            }
            return result;
        }
    }
}
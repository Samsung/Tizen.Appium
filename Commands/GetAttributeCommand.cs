using System;

namespace Tizen.Appium
{
    internal class GetAttributeCommand : ICommand
    {
        public string Command => Commands.GetAttribute;

        public Result Run(Request req)
        {
            Log.Debug("Run: GetAttribute");

            var elementId = req.Params.ElementId;
            var propertyName = req.Params.Attribute;

            var result = new Result();

            var element = AppAdapter.ObjectList.Get(elementId);
            if (element == null)
            {
                Log.Debug("Not Found Element");
                return result;
            }

            var value = element.GetType().GetProperty(propertyName)?.GetValue(element);
            if (value != null)
            {
                result.Value = value.ToString();
                return result;
            }

            Log.Debug(elementId + " element does not have " + propertyName + " property.");
            return result;
        }
    }
}

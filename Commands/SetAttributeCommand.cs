using System;

namespace Tizen.Appium
{
    internal class SetAttributeCommand : ICommand
    {
        public string Command => Commands.SetAttribute;

        public Result Run(Request req)
        {
            Log.Debug("Run: SetAttribute");

            var elementId = req.Params.ElementId;
            var propertyName = req.Params.Attribute;
            var newValue = req.Params.Value;

            var result = new Result();

            var element = AppAdapter.ObjectList.Get(elementId);
            if (element == null)
            {
                Log.Debug("Not Found Element");
                return result;
            }

            var property = element.GetType().GetProperty(propertyName);
            if (property == null)
            {
                Log.Debug(elementId + " element does not have " + propertyName + " property.");
                return result;
            }

            try
            {
                var valueType = property.GetValue(element).GetType();
                var value = ConvertType(newValue, valueType);
                Log.Debug(newValue + " is converted to " + value + "(" + valueType + ")");
                property.SetValue(element, value);

                result.Value = true;
                return result;
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
                result.Value = false;
                return result;
            }
        }

        object ConvertType(string value, Type type)
        {
            return Convert.ChangeType(value, type);
        }
    }
}
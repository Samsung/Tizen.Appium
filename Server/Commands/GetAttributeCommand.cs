namespace Tizen.Appium
{
    public class GetAttributeCommand : ICommand
    {
        public string Command => Commands.GetAttribute;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            Log.Debug("Run: GetAttribute");

            var elementId = req.Params.ElementId;
            var propertyName = req.Params.Attribute;

            var result = new Result();

            var value = objectList.Get(elementId)?.GetPropertyValue(propertyName);
            if (value != null)
            {
                result.Value = value.ToString();
                Log.Debug(elementId + " element have " + propertyName + " property.");
            }
            else
            {
                Log.Debug(elementId + " element does not have " + propertyName + " property.");
            }

            return result;
        }
    }
}

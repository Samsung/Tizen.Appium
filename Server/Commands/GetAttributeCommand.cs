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

            var element = objectList.Get(elementId);
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

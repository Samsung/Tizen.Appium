namespace Tizen.Appium
{
    public class GetEnabledCommand : ICommand
    {
        public string Command => Commands.GetEnabled;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            Log.Debug("Run: GetEnabled");

            var elementId = req.Params.ElementId;

            var result = new Result();


            var element = objectList.Get(elementId);
            if(element == null)
            {
                Log.Debug("Not Found Element");
                return result;
            }

            var value = element.GetType().GetProperty("IsEnabled")?.GetValue(element);
            if (value != null)
            {
                result.Value = value.ToString();
                return result;
            }

            Log.Debug(elementId + " element does not have IsEnabled property.");
            return result;
        }
    }
}

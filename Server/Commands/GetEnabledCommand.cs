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

            var value  = objectList.Get(elementId)?.GetPropertyValue("IsEnabled");
            if(value != null)
            {
                result.Value = value;
            }

            return result;
        }
    }
}

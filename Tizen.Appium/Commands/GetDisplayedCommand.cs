namespace Tizen.Appium
{
    public class GetDisplayedCommand : ICommand
    {
        public string Command => Commands.GetDisplayed;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            Log.Debug("Run: GetDisplayed");

            var elementId = req.Params.ElementId;

            var result = new Result();
            var element = objectList.Get(elementId);
            result.Value = (element != null) ? true : false;

            return result;
        }
    }
}

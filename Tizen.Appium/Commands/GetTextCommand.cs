namespace Tizen.Appium
{
    public class GetTextCommand : ICommand
    {
        public string Command => Commands.GetText;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            Log.Debug("Run: GetText");

            var elementId = req.Params.ElementId;

            var result = new Result();
            var value = objectList.Get(elementId)?.Text;
            if(value != null)
            {
                result.Value = value;
            }

            return result;
        }
    }
}

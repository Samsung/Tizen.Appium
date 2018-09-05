namespace Tizen.Appium
{
    internal class GetTextCommand : ICommand
    {
        public string Command => Commands.GetText;

        public Result Run(Request req)
        {
            Log.Debug("Run: GetText");

            var elementId = req.Params.ElementId;

            var result = new Result();
            result.Value = AppAdapter.Instance.ObjectList.GetTextbyId(elementId);

            return result;
        }
    }
}

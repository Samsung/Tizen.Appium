namespace Tizen.Appium
{
    internal class FindCommand : ICommand
    {
        public string Command => Commands.Find;

        public Result Run(Request req)
        {
            Log.Debug("Run: Find");

            var elementId = req.Params.ElementId;

            var result = new Result();

            if (ElementUtils.ContainsKey(elementId))
            {
                result.Value = true;
            }
            else
            {
                result.Value = false;
            }

            return result;
        }
    }
}

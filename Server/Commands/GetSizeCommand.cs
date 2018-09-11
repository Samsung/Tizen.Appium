using Newtonsoft.Json;

namespace Tizen.Appium
{
    public class GetSizeCommand : ICommand
    {
        public string Command => Commands.GetSize;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            Log.Debug("Run: GetSize");

            var elementId = req.Params.ElementId;

            var result = new Result();
            var geometry = objectList.GetGeometry(elementId);
            result.Value = new Result.Size(geometry.Width, geometry.Height);

            return result;
        }
    }
}

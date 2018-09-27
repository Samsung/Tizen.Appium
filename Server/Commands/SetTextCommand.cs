using System;

namespace Tizen.Appium
{
    public class SetTextCommand : ICommand
    {
        public string Command => Commands.SetText;

        public Result Run(Request req, IObjectList objectList, IInputGenerator inputGen)
        {
            Log.Debug("Run: SetText");

            var elementId = req.Params.ElementId;
            var newValue = req.Params.Text;
            var replace = req.Params.Replace;
            var result = new Result();

            if(string.IsNullOrEmpty(elementId))
            {
                var focused = objectList.GetFocusedElementIds();
                foreach (var id in focused)
                {
                    if (objectList.Get(id)?.HasProperty("Text") == true)
                        elementId = id;
                }
                Log.Debug("Find last focused element to set text : " + elementId);
            }

            if (string.IsNullOrEmpty(elementId))
            {
                Log.Debug("There is no element to set Text");
                return result;
            }

            var oldValue = objectList.Get(elementId)?.GetPropertyValue("Text");
            if (!replace)
            {
                newValue = oldValue + newValue;
            }

            var ret = objectList.Get(elementId)?.SetPropertyValue("Text", newValue);
            if(ret == true)
            {
                result.Value = ret;
            }

            return result;
        }
    }
}
using System;

namespace Tizen.Appium
{
    internal class GetTextCommand : ICommand
    {
        public string Command => Commands.GetText;

        public Result Run(Request req)
        {
            Log.Debug("Run: GetText");

            var elementId = req.Params.ElementId;
            var textProperty = "Text";
            var formattedTextProperty = "FormattedText";

            var result = new Result();

            var element = AppAdapter.ObjectList.Get(elementId);
            if (element == null)
            {
                Log.Debug("Not Found Element");
                return result;
            }

            var text = element.GetType().GetProperty(textProperty)?.GetValue(element);
            var formattedText = element.GetType().GetProperty(formattedTextProperty)?.GetValue(element);
            object retVal = new object();

            if (text == null)
            {
                if (formattedText == null)
                {
                    retVal = String.Empty;
                }
                else
                {
                    retVal = formattedText;
                }
            }
            else
            {
                retVal = text;
            }

            result.Value = retVal.ToString();
            return result;
        }
    }
}

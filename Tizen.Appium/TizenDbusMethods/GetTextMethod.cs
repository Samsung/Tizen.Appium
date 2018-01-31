using System;
using Tizen.Appium.Dbus;

namespace Tizen.Appium
{
    public class GetTextMethod : IDbusMethod
    {
        public string Name => MethodNames.GetText;

        public string Signature => "s";

        public string ReturnSignature => "s";

        public string[] Args => new string[] { Params.ElementId };

        public Arguments Run(Arguments args)
        {
            Log.Debug(TizenAppium.Tag, "#### GetText");

            var elementId = (string)args[Params.ElementId];
            var textProperty = "Text";
            var formattedTextProperty = "FormattedText";

            var ret = new Arguments();

            var element = ElementUtils.GetTestableElement(elementId);
            if (element == null)
            {
                Log.Debug(TizenAppium.Tag, "### Not Found Element");
                ret.SetArgument(Params.Return, string.Empty);
                return ret;
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

            ret.SetArgument(Params.Return, retVal.ToString());
            return ret;
        }
    }
}

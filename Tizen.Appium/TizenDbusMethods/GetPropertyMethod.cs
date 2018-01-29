using Tizen.Appium.Dbus;

namespace Tizen.Appium
{
    public class GetPropertyMethod : IDbusMethod
    {
        public string Name => MethodNames.GetProperty;

        public string Signature => "ss";

        public string ReturnSignature => "s";

        public string[] Args => new string[] { Params.ElementId, Params.PropertyName };

        public Arguments Run(Arguments args)
        {
            Log.Debug(TizenAppium.Tag, "#### GetProperty");

            var elementId = (string)args[Params.ElementId];
            var propertyName = (string)args[Params.PropertyName];

            var ret = new Arguments();

            var element = ElementUtils.GetTestableElement(elementId);
            if (element == null)
            {
                Log.Debug(TizenAppium.Tag, "### Not Found Element");
                ret.SetArgument(Params.Return, string.Empty);
                return ret;
            }

            var value = element.GetType().GetProperty(propertyName)?.GetValue(element);
            object retVal = new object();
            if (value != null)
            {
                retVal = value;
                ret.SetArgument(Params.Return, retVal.ToString());
                return ret;
            }

            var item = ElementUtils.GetTestableItem(propertyName);
            if (item != null)
            {
                retVal = item.GetHashCode();
                ret.SetArgument(Params.Return, retVal.ToString());
                return ret;
            }

            Log.Debug(TizenAppium.Tag, "### " + elementId + " element does not have " + propertyName + " property.");
            retVal = string.Empty;
            ret.SetArgument(Params.Return, retVal.ToString());
            return ret;
        }
    }
}

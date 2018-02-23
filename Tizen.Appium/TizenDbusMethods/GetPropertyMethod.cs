using System;
using Tizen.Appium.Dbus;
using ElmSharp;

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
            Log.Debug(TizenAppium.Tag, "GetProperty");

            var elementId = (string)args[Params.ElementId];
            var propertyName = (string)args[Params.PropertyName];

            var ret = new Arguments();

            var element = ElementUtils.GetTestableElement(elementId);
            if (element == null)
            {
                Log.Debug(TizenAppium.Tag, "Not Found Element");
                ret.SetArgument(Params.Return, string.Empty);
                return ret;
            }

            element = (element is ItemObject) ? ((ItemObject)element).TrackObject : element;

            var value = element.GetType().GetProperty(propertyName)?.GetValue(element);
            if (value != null)
            {
                if (value is Xamarin.Forms.Element)
                {
                    var id = ElementUtils.GetTestableElementId(value);
                    if (!String.IsNullOrEmpty(id))
                    {
                        value = id;
                    }
                }

                ret.SetArgument(Params.Return, value.ToString());
                return ret;
            }

            var item = ElementUtils.GetTestableItem(propertyName);
            if (item != null)
            {
                ret.SetArgument(Params.Return, item.GetHashCode().ToString());
                return ret;
            }

            Log.Debug(TizenAppium.Tag, elementId + " element does not have " + propertyName + " property.");
            ret.SetArgument(Params.Return, String.Empty);

            return ret;
        }
    }
}

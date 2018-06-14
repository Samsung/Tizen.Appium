using System;
using Xamarin.Forms;

namespace Tizen.Appium
{
    internal class SetAttributeCommand : ICommand
    {
        public string Command => Commands.SetAttribute;

        public Result Run(Request req)
        {
            Log.Debug("Run: SetAttribute");

            var elementId = req.Params.ElementId;
            var propertyName = req.Params.Attribute;
            var newValue = req.Params.Value;

            var result = new Result();

            var element = ElementUtils.GetElementWrapper(elementId)?.Element;
            if (element == null)
            {
                Log.Debug("Not Found Element");
                return result;
            }

            var property = element.GetType().GetProperty(propertyName);
            if (property == null)
            {
                Log.Debug(elementId + " element does not have " + propertyName + " property.");
                return result;
            }

            try
            {
                if (property.GetValue(element) is Element)
                {
                    var obj = ElementUtils.GetElementWrapper(newValue).Element;
                    if (obj != null)
                    {
                        property.SetValue(element, obj);
                    }
                }
                else
                {
                    var valueType = property.GetValue(element).GetType();
                    var value = ConvertType(newValue, valueType);
                    Log.Debug(newValue + " is converted to " + value + "(" + valueType + ")");
                    property.SetValue(element, value);
                }

                result.Value = true;
                return result;
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
                result.Value = false;
                return result;
            }
        }

        object ConvertType(string value, Type type)
        {
            TypeConverter converter = null;
            if (type == typeof(Xamarin.Forms.LayoutOptions))
            {
                converter = new LayoutOptionsConverter();
            }
            else if (type == typeof(Color))
            {
                converter = new ColorTypeConverter();
            }
            else if (type == typeof(ConstraintType))
            {
                converter = new ConstraintTypeConverter();
            }
            else if (type == typeof(FileImageSource))
            {
                converter = new FileImageSourceConverter();
            }
            else if (type == typeof(FlexAlignItems))
            {
                converter = new FlexAlignItemsTypeConverter();
            }
            else if (type == typeof(FlexAlignContent))
            {
                converter = new FlexAlignContentTypeConverter();
            }
            else if (type == typeof(FlexDirection))
            {
                converter = new FlexDirectionTypeConverter();
            }
            else if (type == typeof(FlexJustify))
            {
                converter = new FlexJustifyTypeConverter();
            }
            else if (type == typeof(FlexWrap))
            {
                converter = new FlexWrapTypeConverter();
            }
            else if (type == typeof(FlowDirection))
            {
                converter = new FlowDirectionConverter();
            }
            else if (type == typeof(Font))
            {
                converter = new FontTypeConverter();
            }
            else if (type == typeof(GridLength))
            {
                converter = new GridLengthTypeConverter();
            }
            else if (type == typeof(ImageSource))
            {
                converter = new ImageSourceConverter();
            }
            else if (type == typeof(Rectangle))
            {
                converter = new RectangleTypeConverter();
            }
            else if (type == typeof(TextAlignment))
            {
                converter = new TextAlignmentConverter();
            }
            else if (type == typeof(Thickness))
            {
                converter = new ThicknessTypeConverter();
            }
            else if (type == typeof(WebViewSource))
            {
                converter = new WebViewSourceTypeConverter();
            }
            else if (type == typeof(LineBreakMode))
            {
                return Enum.Parse(typeof(LineBreakMode), value);
            }
            else if (type == typeof(FontAttributes))
            {
                return Enum.Parse(typeof(FontAttributes), value);
            }
            else if (type == typeof(StackOrientation))
            {
                return Enum.Parse(typeof(StackOrientation), value);
            }

            if (converter != null)
            {
                return converter.ConvertFromInvariantString(value);
            }
            else
            {
                return Convert.ChangeType(value, type);
            }
        }
    }
}

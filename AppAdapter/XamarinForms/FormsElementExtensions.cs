using Xamarin.Forms;

namespace Tizen.Appium
{
    public static class FormsElementExtensions
    {
        public static readonly BindableProperty IsShownProperty = BindableProperty.Create("IsShown", typeof(bool), typeof(Element), true);

        public static void SetIsShownProperty(this Element e, bool enabled)
        {
            e.SetValue(IsShownProperty, enabled);
        }

        public static bool GetIsShownProperty(this Element e)
        {
            if (e is Page)
            {
                return (bool)e.GetValue(IsShownProperty);
            }
            else
            {
                return (e.Parent != null) ? e.Parent.GetIsShownProperty() : false;
            }
        }

        public static string GetId(this Element e)
        {
            return string.IsNullOrEmpty(e.AutomationId) ? e.GetHashCode().ToString() : e.AutomationId;
        }
    }
}

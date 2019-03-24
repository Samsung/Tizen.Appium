using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;
using Tizen.Appium;

namespace NUIApp
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
#if UITEST
            TizenAppium.StartService(AppType.NUI);
#endif
            Initialize();
        }

        void Initialize()
        {
            TableView contentContainer = new TableView(3, 1);

            TextLabel label = new TextLabel("Welcome to NUI!");
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.BackgroundColor = Color.White;
            label.TextColor = Color.Black;
            label.PointSize = 12.0f;
            label.HeightResizePolicy = ResizePolicyType.FillToParent;
            label.WidthResizePolicy = ResizePolicyType.FillToParent;
            label.AutomationId = "label";

            TextLabel test = new TextLabel("test");
            test.HorizontalAlignment = HorizontalAlignment.Center;
            test.VerticalAlignment = VerticalAlignment.Center;
            test.BackgroundColor = Color.White;
            test.TextColor = Color.Black;
            test.PointSize = 10.0f;
            test.HeightResizePolicy = ResizePolicyType.FillToParent;
            test.WidthResizePolicy = ResizePolicyType.FillToParent;
            test.AutomationId = "test";

            PushButton button = new PushButton();
            button.LabelText = "Button";
            button.BackgroundColor = Color.White;
            button.HeightResizePolicy = ResizePolicyType.FillToParent;
            button.WidthResizePolicy = ResizePolicyType.FillToParent;
            button.AutomationId = "button";

            button.Clicked += (s, e) =>
            {
                test.Text = "button clicked";
                return true;
            };

            contentContainer.AddChild(label, new TableView.CellPosition(0));
            contentContainer.AddChild(test, new TableView.CellPosition(1));
            contentContainer.AddChild(button, new TableView.CellPosition(2));

            Window.Instance.Add(contentContainer);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}

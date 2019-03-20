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
            TizenAppium.StartService(AppType.NUI);
            Initialize();
        }

        void Initialize()
        {
            Window.Instance.KeyEvent += OnKeyEvent;

            TableView contentContainer = new TableView(3, 1);

            TextLabel text = new TextLabel("Hello Tizen NUI World");
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.TextColor = Color.White;
            text.PointSize = 12.0f;
            text.HeightResizePolicy = ResizePolicyType.FillToParent;
            text.WidthResizePolicy = ResizePolicyType.FillToParent;
            text.AutomationId = "text";

            TextLabel test = new TextLabel("test");
            test.HorizontalAlignment = HorizontalAlignment.Center;
            test.VerticalAlignment = VerticalAlignment.Center;
            test.TextColor = Color.White;
            test.PointSize = 10.0f;
            test.HeightResizePolicy = ResizePolicyType.FillToParent;
            test.WidthResizePolicy = ResizePolicyType.FillToParent;
            test.AutomationId = "test";

            PushButton button = new PushButton();
            button.LabelText = "Button";
            button.HeightResizePolicy = ResizePolicyType.FillToParent;
            button.WidthResizePolicy = ResizePolicyType.FillToParent;
            button.AutomationId = "button";

            button.Clicked += (s, e) =>
            {
                test.Text = "button clicked";
                return true;
            };

            contentContainer.AddChild(text, new TableView.CellPosition(0));
            contentContainer.AddChild(test, new TableView.CellPosition(1));
            contentContainer.AddChild(button, new TableView.CellPosition(2));

            Window.Instance.Add(contentContainer);
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}

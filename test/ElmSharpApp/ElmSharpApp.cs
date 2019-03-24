using Tizen.Applications;
using ElmSharp;
using Tizen.Appium;

namespace ElmSharpApp
{
    class App : CoreUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            TizenAppium.StartService(AppType.ElmSharp);
            Initialize();
        }

        void Initialize()
        {
            Window window = new Window("ElmSharpApp")
            {
                AvailableRotations = DisplayRotation.Degree_0 | DisplayRotation.Degree_180 | DisplayRotation.Degree_270 | DisplayRotation.Degree_90
            };
            window.BackButtonPressed += (s, e) =>
            {
                Exit();
            };
            window.Show();

            var box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            box.Show();

            var bg = new Background(window)
            {
                Color = Color.White
            };
            bg.SetContent(box);

            var conformant = new Conformant(window);
            conformant.Show();
            conformant.SetContent(bg);

            var label = new Label(window)
            {
                AlignmentX = 0.5,
                AlignmentY = 0.5,
                WeightX = 1,
                WeightY = 1,
                Text = "Welcome to ElmSharp!",
                Color = Color.Black,
                AutomationId = "label"
            };
            var test = new Label(window)
            {
                AlignmentX = 0.5,
                AlignmentY = 0.5,
                WeightX = 1,
                WeightY = 1,
                Text = "test",
                Color = Color.Black,
                AutomationId = "test"
            };

            var button = new Button(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Text = "button",
                AutomationId = "button"
            };
            button.Clicked += (s, e) =>
            {
                test.Text = "button Clicked";
            };

            label.Show();
            test.Show();
            button.Show();
            box.PackEnd(label);
            box.PackEnd(test);
            box.PackEnd(button);
        }

        static void Main(string[] args)
        {
            Elementary.Initialize();
            Elementary.ThemeOverlay();
            App app = new App();
            app.Run(args);
        }
    }
}

using Tizen.Appium;

namespace FormsApp
{
    class Program : global::Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            TizenAppium.StartService();
            LoadApplication(new App());
        }

        protected override void OnTerminate()
        {
            base.OnTerminate();
            TizenAppium.StopService();
        }

        static void Main(string[] args)
        {
            var app = new Program();
            global::Xamarin.Forms.Platform.Tizen.Forms.Init(app);
            app.Run(args);
        }
    }
}

using Tizen.Appium;

namespace FormsApp
{
    class Program : global::Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
#if UITEST
            TizenAppium.StartService();
#endif
            LoadApplication(new App());
        }

        protected override void OnTerminate()
        {
#if UITEST
            TizenAppium.StopService();
#endif
            base.OnTerminate();
        }

        static void Main(string[] args)
        {
            var app = new Program();
            global::Xamarin.Forms.Platform.Tizen.Forms.Init(app);
            app.Run(args);
        }
    }
}

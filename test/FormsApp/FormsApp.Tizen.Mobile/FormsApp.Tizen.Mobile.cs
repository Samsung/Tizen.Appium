using System;

namespace FormsApp
{
    class Program : global::Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            LoadApplication(new App());
        }

        protected override void OnTerminate()
        {
            base.OnTerminate();
            global::Tizen.Appium.TizenAppium.StopService();
        }

        static void Main(string[] args)
        {
            var app = new Program();
            global::Tizen.Appium.TizenAppium.StartService();
            global::Xamarin.Forms.Platform.Tizen.Forms.Init(app);
            app.Run(args);
        }
    }
}

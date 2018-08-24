using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tizen.Appium
{
    public class FormsAppiumServer : Server
    {
        protected override Result RunCommand(Request req)
        {
            ICommand cmd = null;
            var result = new Result();

            if (Command.TryGetValue(req.Action, out cmd))
            {
                var tcs = new TaskCompletionSource<Result>();

                // Element should be controlled in main loop thread.
                Device.BeginInvokeOnMainThread(() =>
                {
                    tcs.SetResult(cmd.Run(req));
                });

                result = tcs.Task.Result;
            }
            else
            {
                Log.Debug("Not Found action");
            }

            return result;
        }
    }
}

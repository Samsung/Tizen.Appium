using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tizen.Appium
{
    internal class TizenAppiumServer : Server
    {
        IDictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();

        public TizenAppiumServer(IPAddress address = null, int port = 8888) : base(address, port)
        {
            InitCommands();
        }

        protected override string DataReceived(string data)
        {
            var req = JsonConvert.DeserializeObject<Request>(data);

            ICommand cmd = null;
            var result = new Result();

            if (_commands.TryGetValue(req.Action, out cmd))
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
                Log.Debug("Not Founnd action");
            }

            var str = JsonConvert.SerializeObject(result);

            return str;
        }

        void InitCommands()
        {
            Log.Debug("InitCommands");

            Assembly asm = typeof(TizenAppiumServer).GetTypeInfo().Assembly;
            Type methodType = typeof(ICommand);

            var commands = from method in asm.GetTypes()
                           where methodType.IsAssignableFrom(method) && !method.GetTypeInfo().IsInterface && !method.GetTypeInfo().IsAbstract
                           select Activator.CreateInstance(method) as ICommand;

            foreach (var cmd in commands)
            {
                _commands.Add(cmd.Command, cmd);
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;

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
                result = cmd.Run(req);
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

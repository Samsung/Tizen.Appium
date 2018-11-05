using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Tizen.Applications;

namespace Tizen.Appium
{
    public sealed class Server
    {
        static Server s_server;

        ManualResetEvent _receivedDone = new ManualResetEvent(false);
        IDictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();
        InputGenerator _inputgenerator;
        IAppAdapter _appAdapter;
        bool _receivedStop = false;
        IPEndPoint _ipep;
        Socket _socket;

        public static Server Instance
        {
            get
            {
                if (s_server == null)
                    s_server = new Server();

                return s_server;
            }
        }

        Server()
        {
            InitCommand();
        }

        public void Start(CoreApplication application, IPAddress address = null, int port = 8888)
        {

            if (address == null)
            {
                _ipep = new IPEndPoint(IPAddress.Any, port);
            }
            else
            {
                _ipep = new IPEndPoint(address, port);
            }

            if (_socket == null)
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            }

            _appAdapter = AppAdapter.Create(application);
            _inputgenerator = new InputGenerator();

            Bind();

            Log.Debug("Start Server: " + _ipep.ToString() + ", ReuseAddress: true");
        }

        public void Stop()
        {
            _inputgenerator.Dispose();

            if (_socket != null)
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
                Log.Debug("Closed");
            }
        }

        void InitCommand()
        {
            Log.Debug("InitCommands");

            Assembly asm = typeof(Server).GetTypeInfo().Assembly;
            Type methodType = typeof(ICommand);

            var commands = from method in asm.GetTypes()
                           where methodType.IsAssignableFrom(method) && !method.GetTypeInfo().IsInterface && !method.GetTypeInfo().IsAbstract
                           select Activator.CreateInstance(method) as ICommand;

            foreach (var cmd in commands)
            {
                _commands.Add(cmd.Command, cmd);
            }
        }

        void Bind()
        {
            try
            {
                _socket.Bind(_ipep);
                _socket.Listen(10);
                _socket.BeginAccept(new AsyncCallback(AcceptCallback), _socket);
                Log.Debug("Listen...");
            }
            catch (Exception e)
            {
                Log.Debug("Failed to initiate socket");
                Log.Debug(e.ToString());
            }
        }

        Result RunCommand(Request req)
        {
            ICommand cmd = null;
            var result = new Result();

            if (_commands.TryGetValue(req.Action, out cmd))
            {
                result =  cmd.Run(req, _appAdapter.ObjectList, _inputgenerator);
            }
            else
            {
                Log.Debug("Not Found action");
            }
            return result;
        }

        void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                Socket listener = (Socket)ar.AsyncState;
                Socket client = listener.EndAccept(ar);
                _receivedStop = false;

                Log.Debug("Connected: " + client.RemoteEndPoint.ToString());

                while (!_receivedStop)
                {
                    _receivedDone.Reset();

                    StateObject state = new StateObject();
                    state.WorkSocket = client;

                    client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceivedCallback), state);
                    _receivedDone.WaitOne();
                }
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
            }
        }

        void ReceivedCallback(IAsyncResult ar)
        {
            String content = String.Empty;
            StateObject state = (StateObject)ar.AsyncState;
            Socket client = state.WorkSocket;

            try
            {
                int read = client.EndReceive(ar);
                if (read > 0)
                {
                    var encoder = Encoding.GetEncoding("iso-8859-1");
                    content = encoder.GetString(state.Buffer, 0, read - 2);
                    Log.Debug("Received Data: " + content);

                    var req = JsonConvert.DeserializeObject<Request>(content);
                    var result = new Result();

                    result = RunCommand(req);

                    var str = JsonConvert.SerializeObject(result);
                    Log.Debug("Result: " + result);

                    Byte[] ret = Encoding.Default.GetBytes(str);
                    client.Send(ret);
                }
                else
                {
                    //if the socekt is crashed, invoke broken pipe exception to close the socket.
                    Byte[] ret = new Byte[1];
                    client.Send(ret);
                }
            }
            catch (SocketException se)
            {
                Log.Debug(se.ToString());

                _receivedStop = true;
                client.Close();
                _socket.Disconnect(true);

                Log.Debug("Reset ServerSocket");
                Bind();
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
            }
            finally
            {
                _receivedDone.Set();
            }
        }
    }
}

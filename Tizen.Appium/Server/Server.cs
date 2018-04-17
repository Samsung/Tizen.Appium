using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Tizen.Appium
{
    internal abstract class Server
    {
        ManualResetEvent _receivedDone = new ManualResetEvent(false);
        bool _receivedStop = false;

        protected abstract string DataReceived(string data);

        IPEndPoint _ipep;
        Socket _socket;

        protected Server(IPAddress address, int port)
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
            }

            Log.Debug("Start Server: " + _ipep.ToString());
            Start();
        }

        void Start()
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

        public void Stop()
        {
            if (_socket != null)
            {
                _socket.Close();
            }
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

                    var result = DataReceived(content);

                    Log.Debug("Result: " + result);

                    Byte[] ret = Encoding.Default.GetBytes(result);
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
                Start();
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

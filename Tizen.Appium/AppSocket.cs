using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ElmSharp;
using System.Runtime.InteropServices;
using T = Tizen;

namespace Tizen.Appium
{
    public class AppSocket
    {
        Socket socket;
        int port = 9090;
        string LogTag = "Appium";
        StateObject state;

        public AppSocket()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void StartListening()
        {
            T.Log.Debug(LogTag, "Enter");
            var ep = new IPEndPoint(IPAddress.Any, port);
            socket.Bind(ep);
            socket.Listen(1);
            socket.BeginAccept(new AsyncCallback(AcceptCallback), socket);
        }

        public void StopListening()
        {
            Close();
        }

        void AcceptCallback(IAsyncResult ar)
        {
            T.Log.Debug(LogTag, "Enter ");
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            state = new StateObject();
            state.workSocket = handler;

            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        void ReadCallback(IAsyncResult ar)
        {
            T.Log.Debug(LogTag, "Enter");
            string content = string.Empty;

            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                state.sb.Clear();
                state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));

                content = state.sb.ToString();
                T.Log.Debug(LogTag, "Message : " + content);
                char[] delimiter = { '/' };
                string[] msg = content.Split(delimiter);

                if (msg[0].Equals("GetPosition"))
                {
                    string autoId = msg[1];
                    T.Log.Debug(LogTag, "autoId : " + autoId);

                    Send(handler, "300/400");

                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                }
                else if (msg[0].Equals("SetCommand"))
                {
                    string reqNum = msg[1];
                    string autoId = msg[2];
                    string action = msg[3];

                    T.Log.Debug(LogTag, "reqNum : " + reqNum);
                    T.Log.Debug(LogTag, "autoId : " + autoId);
                    T.Log.Debug(LogTag, "action : " + action);  // element:click

                    Send(handler, "True");
                    //BroadcastSignal();
                }
            }
        }

        void Send(Socket handler, String data)
        {
            T.Log.Debug(LogTag, "Enter : " + data);
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.UTF8.GetBytes(data);

            // Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        void BroadcastSignal()
        {
            Send(state.workSocket, "Broadcast Signal"); 
        }

        void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                T.Log.Debug(LogTag, "Sent bytes to client." + bytesSent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Close()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }

    public class StateObject
    {
        public Socket workSocket = null;

        // Size of receive buffer.
        public const int BufferSize = 1024;

        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];

        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }
}
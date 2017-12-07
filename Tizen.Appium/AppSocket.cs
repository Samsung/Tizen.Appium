using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tizen.Appium
{
    public class ReceivedEventArgs
    {
        public Socket Socket { get; private set; }
        public string Data { get; private set; }

        public ReceivedEventArgs(Socket s, string data)
        {
            Socket = s;
            Data = data;
        }
    }

    public class AppSocket
    {
        Socket socket;
        int port = 9090;
        StateObject state;

        public event EventHandler Accepted;

        public event EventHandler<ReceivedEventArgs> Received;

        public event EventHandler SendCompleted;

        public AppSocket()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void StartListening()
        {
            Console.WriteLine("#### StartListening");
            var ep = new IPEndPoint(IPAddress.Any, port);
            socket.Bind(ep);
            socket.Listen(1);
            socket.BeginAccept(new AsyncCallback(AceeptedCallback), socket);
        }

        public void StopListening()
        {
            Console.WriteLine("#### StopListening");
            Close();
        }

        public void Send(String message)
        {
            Console.WriteLine("#### Send: {0}", message);

            if (state.workSocket == null)
            {
                Console.WriteLine("#### socket is not created yet!!");
                return;
            }

            var handler = state.workSocket;
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.UTF8.GetBytes(message);

            // Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        void AceeptedCallback(IAsyncResult ar)
        {
            Console.WriteLine("#### AceeptedCallback");
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            state = new StateObject();
            state.workSocket = handler;

            Accepted?.Invoke(this, EventArgs.Empty);

            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceivedCallback), state);
        }

        void ReceivedCallback(IAsyncResult ar)
        {
            Console.WriteLine("#### ReceivedCallback");
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceivedCallback), state);

            int bytesRead = handler.EndReceive(ar);
            string content = String.Empty;

            if (bytesRead > 0)
            {
                state.sb.Clear();
                state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));

                content = state.sb.ToString();
            }

            var arg = new ReceivedEventArgs(handler, content);
            Received?.Invoke(this, arg);
        }

        void SendCallback(IAsyncResult ar)
        {
            Console.WriteLine("#### SendCallback");
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent bytes to client." + bytesSent);

                SendCompleted?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Close()
        {
            Console.WriteLine("#### Close");
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
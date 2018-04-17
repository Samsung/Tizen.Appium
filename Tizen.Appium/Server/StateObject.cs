using System.Net.Sockets;

namespace Tizen.Appium
{
    public class StateObject
    {
        // Client  socket
        public Socket WorkSocket = null;

        // Size of receive buffer
        public const int BufferSize = 1024;

        // Receive buffer
        public byte[] Buffer = new byte[BufferSize];
    }
}

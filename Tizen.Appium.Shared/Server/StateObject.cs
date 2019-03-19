using System.Net.Sockets;

namespace Tizen.Appium
{
    public class StateObject
    {
        public Socket WorkSocket = null;

        public const int BufferSize = 1024;

        public byte[] Buffer = new byte[BufferSize];
    }
}

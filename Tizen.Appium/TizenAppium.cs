using System;
using Xamarin.Forms;

namespace Tizen.Appium
{
    public class TizenAppium
    {
        public static bool IsInitialized { get; private set; }

        public static AppSocket _socket;
        public static TestRunner _testRunner;

        public static DbusConnection _dbusConn;

        public static void Init()
        {
            if (IsInitialized)
                return;

            IsInitialized = true;
        }

        public static void StartService()
        {
            Console.WriteLine("### StartService");
            if (IsInitialized)
                return;

            _testRunner = new TestRunner();
            _socket = new AppSocket();
            _socket.StartListening();
            _socket.Accepted += SocketAccepted;
            _socket.Received += SocketReceived;

            IsInitialized = true;

            //TEST
            //Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@1111");
            ////_bus = new TestDbus();
            //_dbusConn = new DbusConnection();
            //Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@22222");
        }

        static void StopService()
        {
            Console.WriteLine("### StopService");
            _socket.StopListening();
        }

        static void SocketAccepted(object sender, EventArgs arg)
        {
            Console.WriteLine("### SocketAccepted");
            _testRunner.TestCompleted += (s, e) =>
            {
                Console.WriteLine(" ### TestCompleted");
                var message = e.RequestId + "/" + e.AutomationId + "/" + e.Command;
                _socket.Send(message);
            };
        }

        static void SocketReceived(object sender, ReceivedEventArgs arg)
        {
            Console.WriteLine("### SocketAccepted : {0}", arg.Data);
            char[] delimiter = { '/' };
            string[] msg = arg.Data.Split(delimiter);

            if (msg[0].Equals("GetPosition"))
            {
                string autoId = msg[1];
                Console.WriteLine("### GetPosition: automationId={0}", autoId);

                var ve = TestHelper.GetTestableElement(autoId) as VisualElement;
                var message = "";

                int x = (int)(ve.X + (ve.Width / 2));
                int y = (int)(ve.Y + (ve.Height / 2));

                if (ve != null)
                    message += x + "/" + y;

                _socket.Send(message);
            }
            else if (msg[0].Equals("SetCommand"))
            {
                string reqId = msg[1];
                string autoId = msg[2];
                string command = msg[3];

                Console.WriteLine("### SetCommand: reqId={0}, automation={1}, action={2}", reqId, autoId, command);
                Console.WriteLine("reqNum : " + reqId);
                Console.WriteLine("autoId : " + autoId);
                Console.WriteLine("action : " + command);  // element:click

                var ret = _testRunner.RunCommand(reqId, autoId, command);
                var message = "";

                if (ret)
                    message = "True";
                else
                    message = "False";

                _socket.Send(message);
            }
        }

        //for testing
        public void test()
        {
            Console.WriteLine(" ### test ");
            _testRunner.RunCommand("1", "111", TestCommands.ClickCommand);

            var element = TestHelper.GetTestableElement("111");

            if (element == null)
            {
                Console.WriteLine("@@@@@@@@@@@ element is null");
            }
            else
            {
                var ve = element as VisualElement;
                Console.WriteLine("autoId={0}, x={1}, y={2}, width={3}, height={4}", ve.AutomationId, ve.X, ve.Y, ve.Width, ve.Height);

                (element as Xamarin.Forms.Button).Clicked += (s, e) =>
                {
                    Console.WriteLine("autoId={0}, x={1}, y={2}, width={3}, height={4}", ve.AutomationId, ve.X, ve.Y, ve.Width, ve.Height);
                };
            }
        }
    }
}
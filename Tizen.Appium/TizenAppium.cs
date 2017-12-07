using System;
using System.Collections.Generic;
using ElmSharp;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Tizen.Appium
{
    public class TizenAppium
    {
        AppSocket Socket;

        public TizenAppium(Window window)
        {
            Socket = new AppSocket();
            Socket.StartListening();

            //var myEdbus = new Edbus();
            //myEdbus.Initialize();
        }

        public void StartService()
        {
        }

        public void StopService()
        {
        }
    }
}
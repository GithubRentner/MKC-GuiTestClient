using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace GuiTestClient
{
    class TestClient
    {
        public static ServerSocket socket;
        private static int _port = 3018;
        private static string _host = "localhost";

        public static List<string> allMessages = new List<string>();
        public static object listLock = new Object();

        public static event EventHandler<string> IncomingMessageEvent;
        public static event EventHandler<bool> ConnectionStatusChanged;

        public static bool IsConnected = false;

        public static void EstablishConnection()
        {
            
            string url = "ws://" + _host + ":" + _port + "/";
            socket = new ServerSocket(url);

            socket.OnOpen += (sender, e) =>
            {
                IsConnected = true;
                OnConnectionStatusChanged(true);
            };

            socket.OnClose += (sender, e) =>
            {
                IsConnected = false;
                OnConnectionStatusChanged(false);
            };


            socket.Connect();
        }





        public static void SendMessage(string message)
        {
            socket.Send(message);
            AddMessageToList(message);            
        }


        public static void CloseConnection()
        {
            socket.Close();
        }


        public static void AddMessageToList(string message)
        {
            lock (listLock)
            {
                allMessages.Add(message);
            }
        }


        public static string GetMessageFromList(int idx)
        {
            string message;
            lock (listLock)
            {
                message = allMessages.ElementAt(idx);
            }
            return message;
        }


        public static int GetMessageCount()
        {
            int count;
            lock (listLock)
            {
                count = allMessages.Count;
            }
            return count;
        }


        public static void InvokeReceiveEvent(string message)
        {
            IncomingMessageEvent?.Invoke(null, message);
        }


        private static void OnConnectionStatusChanged(bool isConnected)
        {
            ConnectionStatusChanged?.Invoke(null, isConnected);
        }
    }



    public class ServerSocket : WebSocket
    {
        /* Socket configuration */
        public ServerSocket(string url, params string[] protocols) : base(url, protocols)
        {
            // enable TLS settings for the websocket
            SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;

            // add eventfunction for receiving server messages
            OnMessage += WS_OnMessage;
        }

        /* Eventfunction: Print out incoming server messages */
        private void WS_OnMessage(object sender, MessageEventArgs e)
        {
            // read out text of server response
            string responseString = e.Data;

            TestClient.AddMessageToList(responseString);

            TestClient.InvokeReceiveEvent(responseString);
        }
    }
}

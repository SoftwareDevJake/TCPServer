using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ServerHandle
    {
        //public static int GameClientId;
        //public static int JinjuAdministratorId;
        //public static int Jinju_BottomID;

        public static string _info;
        public static int _clientIdCheck;
        public static void WelcomeReceived(int _fromClient, Packet _packet)
        {
            _clientIdCheck = _packet.ReadInt();
            _info = _packet.ReadString();

            Console.WriteLine($"\n{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient}.");
            Console.WriteLine($"\nServer Info : {_info}");


            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"Player \"{_info}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
            }

        }

        public static void receivedMessageTest(int _fromClient, Packet _packet)
        {
            //ServerSend.SendMsgTest(_fromClient, _info);
            _info = _packet.ReadString();
            //Console.WriteLine($"\n{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient}.");
            Console.WriteLine($"\nServer Info Name : {_info}");

            ServerSend.SendUserInfoToAll(_fromClient, _info);
        }

        public static void ReceivedAlerts(int _fromClient, Packet _packet)
        {
            string _alert = _packet.ReadString();
            ServerSend.AlertForAll(_alert);
        }

        public static void ReceivedFloorInfo(int _fromClient, Packet _packet)
        {
            string _floor = _packet.ReadString();

            Console.WriteLine($"\nFloor Info from Client : {_floor}");
            
            ServerSend.FloorInfo(_floor);
        }

        public static void ReceivedScreenshotInfo(int _fromClient, Packet _packet)
        {
            string _screenshotInfo = _packet.ReadString();

            Console.WriteLine($"\n_screenshot Info from Client : {_screenshotInfo}");

            ServerSend.ScreenshotInfo(_screenshotInfo);
        }

        public static void ReceivedPlayersNumber(int _fromClient, Packet _packet)
        {
            string _playersNumber = _packet.ReadString();

            Console.WriteLine($"\n_playersNumber from Client : {_playersNumber}");

            ServerSend.PlayersNumber(_playersNumber);
        }

        public static void ReceivedTrackerId(int _fromClient, Packet _packet)
        {
            string _trackerId = _packet.ReadString();

            Console.WriteLine($"\n_TrackerId from Client : { _trackerId}");

            ServerSend.TrackerId(_trackerId);
        }

        public static void ReceivedCannonFired(int _fromClient, Packet _packet)
        {
            string _cannonFired = _packet.ReadString();

            Console.WriteLine($"\n_cannon Fire from Client : {_cannonFired}");

            ServerSend.CannonFired(_cannonFired);
        }

        public static void ReceivedContentStart(int _fromClient, Packet _packet)
        {
            string _contentStart = _packet.ReadString();

            Console.WriteLine($"\nContent info : {_contentStart}");

            ServerSend.ContentStart(_contentStart);
        }

        public static void ReceivedLanguage(int _fromClient, Packet _packet)
        {
            string _language = _packet.ReadString();

            Console.WriteLine($"\nLanguage Info : {_language}");

            ServerSend.Language(_language);
        }

        public static void ReceivedMode(int _fromClient, Packet _packet)
        {
            string _mode = _packet.ReadString();

            Console.WriteLine($"\nMode Info : {_mode}");

            ServerSend.Mode(_mode);
        }

        public static void ReceivedArrow(int _fromClient, Packet _packet)
        {
            string _arrow = _packet.ReadString();

            Console.WriteLine($"\nArrow : {_arrow}");

            ServerSend.Arrow(_arrow);
        }
        
        public static void ReceivedShutdown(int _fromClient, Packet _packet)
        {
            string _shutdown = _packet.ReadString();

            Console.WriteLine($"Shutdown : {_shutdown}");

            ServerSend.Shutdown(_shutdown);
        }

        public static void ReceivedVideoSkip(int _fromClient, Packet _packet)
        {
            string _skip = _packet.ReadString();

            Console.WriteLine($"Skip : {_skip}");

            ServerSend.VideoSkip(_skip);
        }

        public static void ReceivedRestart(int _fromClient, Packet _packet)
        {
            string _restart = _packet.ReadString();

            Console.WriteLine($"Restart : {_restart}");

            ServerSend.Restart(_restart);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // This is a part you deal with Server when it receives message from client.
    class ServerHandle
    {
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
            _info = _packet.ReadString();
            Console.WriteLine($"\nServer Info Name : {_info}");

            ServerSend.SendUserInfoToAll(_fromClient, _info);
        }
    }
}

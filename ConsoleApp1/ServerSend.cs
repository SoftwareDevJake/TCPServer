using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ServerSend
    {
        private static void SendTCPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            Server.clients[_toClient].tcp.SendData(_packet);
        }

        private static void SendTCPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                Server.clients[i].tcp.SendData(_packet);
            }
        }
        private static void SendTCPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                if (i != _exceptClient)
                {
                    Server.clients[i].tcp.SendData(_packet);
                }
            }
        }

        #region Packets
        public static void Welcome(int _toClient, string _msg)
        {
            using (Packet _packet = new Packet((int)ServerPackets.welcome))
            {
                _packet.Write(_msg);
                //_packet.Write(_msg);
                _packet.Write(_toClient);

                SendTCPData(_toClient, _packet);
            }
        }

        public static void SendUserInfoToAll(int _fromClient, string _info) {
            using(Packet _packet = new Packet((int)ServerPackets.name))
            {
                _packet.Write(_info + "                        ");
                //ServerHandle.receivedMessageTest(_toClient, _packet);

                SendTCPDataToAll(_packet);
            }
        }

        public static void AlertForAll(string _alert)
        {
            using(Packet _packet = new Packet((int)ServerPackets.alerts))
            {
                _packet.Write(_alert);

                SendTCPDataToAll(_packet);
            }
        }

        public static void FloorInfo(string _floor)
        {
            using (Packet _packet = new Packet((int)ServerPackets.FloorInfo))
            {
                _packet.Write(_floor);

                SendTCPDataToAll(_packet);
            }
           
                         
        }

        public static void ScreenshotInfo(string _screenshot)
        {
            using(Packet _packet = new Packet((int)ServerPackets.screenshot))
            {
                _packet.Write(_screenshot);

                SendTCPDataToAll(_packet);
            }
        }

        public static void PlayersNumber(string _playersNumber)
        {
            using (Packet _packet = new Packet((int)ServerPackets.playersNumber))
            {
                _packet.Write(_playersNumber);

                SendTCPDataToAll(_packet);
            }
        }

        public static void TrackerId(string _trackerId)
        {
            using (Packet _packet = new Packet((int)ServerPackets.TrackerId))
            {
                _packet.Write(_trackerId);

                SendTCPDataToAll(_packet);
            }
        }

        public static void CannonFired(string _cannonFired)
        {
            using (Packet _packet = new Packet((int)ServerPackets.CannonFire))
            {
                _packet.Write(_cannonFired);

                SendTCPDataToAll(_packet);
            }
        }

        public static void ContentStart(string _contentStart)
        {
            using (Packet _packet = new Packet((int)ServerPackets.ContentStart))
            {
                _packet.Write(_contentStart);

                SendTCPDataToAll(_packet);
            }
        }

        public static void Language(string _language)
        {
            using (Packet _packet = new Packet((int)ServerPackets.Language))
            {
                _packet.Write(_language);

                SendTCPDataToAll(_packet);
            }
        }

        public static void Mode(string _mode)
        {
            using (Packet _packet = new Packet((int)ServerPackets.Mode))
            {
                _packet.Write(_mode);

                SendTCPDataToAll(_packet);
            }
        }

        public static void Arrow(string _arrow)
        {
            using (Packet _packet = new Packet((int)ServerPackets.Arrow))
            {
                _packet.Write(_arrow);

                SendTCPDataToAll(_packet);
            }
        }

        public static void Shutdown(string _shutdown)
        {
            using(Packet _packet = new Packet((int)ServerPackets.Shutdown))
            {
                _packet.Write(_shutdown);

                SendTCPDataToAll(_packet);
            }
        }

        public static void VideoSkip(string _skip)
        {
            using (Packet _packet = new Packet((int)ServerPackets.videoSkip))
            {
                _packet.Write(_skip);

                SendTCPDataToAll(_packet);
            }
        }

        public static void Restart(string _restart)
        {
            using (Packet _packet = new Packet((int)ServerPackets.restart))
            {
                _packet.Write(_restart);

                SendTCPDataToAll(_packet);
            }
        }
        #endregion
    }
}

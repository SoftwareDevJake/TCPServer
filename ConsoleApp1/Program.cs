using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        private static bool isRunning = false;
        static void Main(string[] args)
        {
            Console.Title = "Game Server";
            isRunning = true;
            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();

            Server.Start(50, 26951);
        }

        private static void MainThread()
        {
            Console.WriteLine($"Main thread started. Running at {Constants.TICKS_PER_SEC} ticks per second.");
            DateTime _nextLoop = DateTime.Now;

            while(isRunning)
            {
                while (_nextLoop < DateTime.Now)
                {
                    GameLogic.Update();

                    _nextLoop = _nextLoop.AddMilliseconds(Constants.MS_PER_TICK);

                    if(_nextLoop > DateTime.Now)
                    {
                        try
                        {
                            //Console.WriteLine("_next loop : " + _nextLoop);
                            TimeSpan timeout = _nextLoop - DateTime.Now;
                            TimeSpan timeMin = TimeSpan.Zero;
                            if(timeout < timeMin)
                            {
                                //Console.WriteLine("hihi");
                                break;
                            }
                            //Console.WriteLine("timeout : " + timeout);
                            Thread.Sleep(timeout);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("e : " + e);
                        }
                    }
                }
            }
        }
    }
}

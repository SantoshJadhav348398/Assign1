using System;
using System.Threading;

namespace MultiThreadA3
{
    class Program
    {
        static Object myLock = new Object();
        static void Main(string[] args)
        {
            Thread ping = new Thread(Monitored);
            Thread pong = new Thread(Monitored);
            ping.Name = "ping";
            pong.Name = "pong";
            ping.Start();
            pong.Start();
            Thread.Sleep(4000);
            Console.WriteLine("Time to end");
        }

        static void Monitored()
        {
            Monitor.Enter(myLock);

            Console.WriteLine($"Current Thread {Thread.CurrentThread.Name} started");
            Thread.Sleep(1000);
            Console.WriteLine($"Current Thread {Thread.CurrentThread.Name} stopped");

            Monitor.Exit(myLock);
        }
    }

}

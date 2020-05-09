using System;
using System.Threading;

namespace MultiThreadingA5
{
    class Program
    {
        static Mutex mut = new Mutex();
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

            mut.WaitOne();
            Console.WriteLine($"Current Thread {Thread.CurrentThread.Name} started");
            Thread.Sleep(1000);
            Console.WriteLine($"Current Thread {Thread.CurrentThread.Name} stopped");

            mut.ReleaseMutex();

        }
    }
}

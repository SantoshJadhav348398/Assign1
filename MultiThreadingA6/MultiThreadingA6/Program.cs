using System;
using System.Threading;

namespace MultiThreadingA6
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread defaultThread = new Thread(StartTheThreading);
            Thread parametrizedThread = new Thread(StartTheThreading);
            defaultThread.Name = "ping";
            parametrizedThread.Name = "pong";
            defaultThread.Start();
            parametrizedThread.Start(42);
            Thread.Sleep(4000);
            Console.WriteLine("Threads are started");
        }


        static void StartTheThreading(object variable)
        {
            Console.WriteLine($"Current Thread {Thread.CurrentThread.Name} started with {variable}");
            Thread.Sleep(1000);
            Console.WriteLine($"Current Thread {Thread.CurrentThread.Name} stopped");

        }
    }
}

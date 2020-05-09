using System;
using System.Threading;

namespace MultiThreadindA1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(StartTheThreading);
            t1.Start();
            Thread.Sleep(4000);
            Console.WriteLine("Started the Thread");
        }

        static void StartTheThreading()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("local = {0}", i);
                Thread.Sleep(1000);
            }
        }
    }
}

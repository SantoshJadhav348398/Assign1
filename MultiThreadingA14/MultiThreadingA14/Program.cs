using System;
using System.Threading;

namespace MultiThreadingA14
{
    class Program
    {
        static void Main(string[] args)
        {
            int worker;
            int io;

            System.Threading.ThreadPool.GetAvailableThreads(out worker, out io);
            Console.WriteLine($"worker = {worker} and io = {io}");

            System.Threading.ThreadPool.SetMaxThreads(32, 10);

            System.Threading.ThreadPool.GetMaxThreads(out worker, out io);
            Console.WriteLine($"worker = {worker} and io = {io}");

            for (var i = 0; i < 10000; i++)
                System.Threading.ThreadPool.QueueUserWorkItem(WorkerThread, i);
            Thread.Sleep(1000);
            //Console.WriteLine("Hello World!");
        }

        static void WorkerThread(object o)
        {
            Console.WriteLine("pool thread" + o);
            Thread.Sleep(1000);
        }
    }
}

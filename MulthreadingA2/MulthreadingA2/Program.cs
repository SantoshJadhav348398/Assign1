using System;
using System.Threading;
namespace MulthreadingA2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread eena = new Thread(StartTheThreading);
            Thread meena = new Thread(StartTheThreading);
            Thread deeka = new Thread(StartTheThreading);
            eena.Start();
            meena.Start();
            deeka.Start();
            Console.WriteLine("Threads are started");
        }

        static void StartTheThreading()
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine("Local = {0}", i);
        }
    }
}

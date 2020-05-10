using System;
using System.Threading;

namespace MultiThreadingA8
{
    class WithInstance
    {
        Object myLock = new Object();
        public void Monitored()
        {

            Monitor.Enter(myLock);

            Console.WriteLine($"Current Thread {Thread.CurrentThread.Name} started");
            Thread.Sleep(1000);
            Console.WriteLine($"Current Thread {Thread.CurrentThread.Name} stopped");

            Monitor.Exit(myLock);
        }
    }

    class LocalInstance
    {

        public void Monitored()
        {
            Object myLock = new Object();
            Monitor.Enter(myLock);

            Console.WriteLine($"Current Thread {Thread.CurrentThread.Name} started");
            Thread.Sleep(1000);
            Console.WriteLine($"Current Thread {Thread.CurrentThread.Name} stopped");

            Monitor.Exit(myLock);
        }
    }

    class InstanceThis
    {

        public void Monitored()
        {
            //Object myLock = new Object();
            Monitor.Enter(this);

            Console.WriteLine($"Current Thread {Thread.CurrentThread.Name} started");
            Thread.Sleep(1000);
            Console.WriteLine($"Current Thread {Thread.CurrentThread.Name} stopped");

            Monitor.Exit(this);
        }
    }
    class Program
    {



        static void Main(string[] args)
        {
            // Creating instance Lock
            WithInstance instanceLock = new WithInstance();
            Thread ping = new Thread(instanceLock.Monitored);
            Thread pong = new Thread(instanceLock.Monitored);

            ping.Name = "ping";
            pong.Name = "pong";
            ping.Start();
            pong.Start();
            Thread.Sleep(4000);

            Console.WriteLine("instance Lock ended");


            // Creating Local Locks
            LocalInstance localLock = new LocalInstance();
            Thread ying = new Thread(localLock.Monitored);
            Thread yang = new Thread(localLock.Monitored);

            ying.Name = "ying";
            yang.Name = "yang";
            ying.Start();
            yang.Start();
            Thread.Sleep(4000);

            Console.WriteLine("local Lock ended kaam ka nhi yeh");

            // Creating This Locks
            InstanceThis thisLock = new InstanceThis();
            Thread jing = new Thread(localLock.Monitored);
            Thread ling = new Thread(localLock.Monitored);

            jing.Name = "jing";
            ling.Name = "ling";
            jing.Start();
            ling.Start();
            Thread.Sleep(4000);

            Console.WriteLine("This Lock ended yeh bhi faltu nikla");

            Console.WriteLine("Time to end");
        }


    }
}

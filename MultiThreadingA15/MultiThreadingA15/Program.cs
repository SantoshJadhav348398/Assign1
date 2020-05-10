using System;

namespace MultiThreadingA15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            System.Threading.Tasks.Task.Run(() => { Console.WriteLine("Performing the tasks"); });
        }
    }
}

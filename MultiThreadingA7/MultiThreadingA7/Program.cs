using System;
using System.Threading;

namespace MultiThreadingA7
{
    class Another
    {
        public void MyInstanceMethod()
        {
            Console.WriteLine("Hello from instance method");
        }

        public (int, string, bool) MultiReturnFunction()
        {
            return (1, "Hello", false);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            // Calling Static Method
            Thread staticMethod = new Thread(MyStaticMethod);
            staticMethod.Start();

            // Calling Instance Method
            Another anotherObj = new Another();
            Thread instanceMethod = new Thread(anotherObj.MyInstanceMethod);
            instanceMethod.Start();

            var (id, name, age) = anotherObj.MultiReturnFunction();

            // Calling Delegate Method
            Thread delegateMethod = new Thread(delegate ()
            {
                Console.WriteLine("delegate Calling");
            });
            delegateMethod.Start();

            // Calling Lambda Method
            Thread LambdaMethod = new Thread(() =>
            {
                Console.WriteLine("lambda Calling");
            });

            LambdaMethod.Start();

            // Calling ThreadStart with no Param
            Thread NoParamThread = new Thread(new ThreadStart(ThreadStartMethod));
            NoParamThread.Start();

            // Calling with Parametrised ThreadStart
            Thread paramThread = new Thread(new ParameterizedThreadStart(ParamMethod));
            paramThread.Start(5000);

        }

        static void MyStaticMethod()
        {
            Console.WriteLine(" hello from static Method");
        }
        static void ThreadStartMethod()
        {
            Console.WriteLine("Called using new ThreadStart");
        }
        static void ParamMethod(object obj)
        {
            if (obj == null)
                throw new Exception("No data");

            Console.WriteLine($"ParaMethod received {obj}");
        }


    }
}

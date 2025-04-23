using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class Locking
    {
        static int counter = 0;
        static object locker = new object(); // Lock object

        static void IncrementCounter()
        {
            for (int i = 0; i < 1000; i++)
            {
                lock (locker)
                {
                    counter++; // Now thread-safe
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                }
            }
        }

        static void Main()
        {
            Thread t1 = new Thread(IncrementCounter);
            Thread t2 = new Thread(IncrementCounter);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine($"Final counter value: {counter}");
        }
    }
}

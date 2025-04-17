using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class Program
    {

        static async Task Main()
        {
            var doWorkTask = DoWork(); // Start the DoWork method
            DoOtherWork(); // Main thread continues to do other work
            //await doWorkTask; // Await the completion of DoWork
            Console.WriteLine("Task completed.");
            Task.Delay(1985).Wait(); // Wait for 2 seconds to see the output of DoOtherWork
        }

        static async Task DoWork()
        {
            await Task.Delay(2000); // Pauses execution for 2 seconds without blocking
            Console.WriteLine("Work done.");
        }

        static void DoOtherWork()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Doing other work {i + 1}");
                Task.Delay(500); // Simulate some work by blocking for 0.5 seconds
            }
        }

    }
}

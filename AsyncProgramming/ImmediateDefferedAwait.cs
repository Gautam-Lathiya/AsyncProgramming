using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class ImmediateDefferedAwait
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Immediate Await ===");
            await ImmediateAwaitExample();

            Console.WriteLine("\n=== Deferred Await ===");
            await DeferredAwaitExample();
        }

        static async Task ImmediateAwaitExample()
        {
            Console.WriteLine($"[Immediate] Start at {DateTime.Now:HH:mm:ss.fff}");

            // Await immediately — method pauses here
            await Task.Delay(3000); // Simulate slow task

            Console.WriteLine($"[Immediate] After await at {DateTime.Now:HH:mm:ss.fff}");
        }

        static async Task DeferredAwaitExample()
        {
            Console.WriteLine($"[Deferred] Start at {DateTime.Now:HH:mm:ss.fff}");

            // Start task but don't await yet
            var task = Task.Delay(3000);

            Console.WriteLine($"[Deferred] Doing other work at {DateTime.Now:HH:mm:ss.fff}");

            // Simulate useful work
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"[Deferred] Log {i + 1} at {DateTime.Now:HH:mm:ss.fff}");
                await Task.Delay(500); // Simulate small delays
            }
            Console.WriteLine($"[Deferred] Afterfor loop ends {DateTime.Now:HH:mm:ss.fff}");
            // Now await the original task
            await task;

            Console.WriteLine($"[Deferred] After await at {DateTime.Now:HH:mm:ss.fff}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class MultiThreading
    {
        //static void Main(string[] args)
        //{
        //    // Create a new thread
        //    Thread thread = new Thread(new ThreadStart(ThreadMethod));
        //    thread.Start();
        //    // Main thread continues to run
        //    Console.WriteLine("Main thread is running...");
        //    // Wait for the thread to finish
        //    thread.Join();
        //    Console.WriteLine("Thread has finished.");
        //}
        //static void ThreadMethod()
        //{
        //    Console.WriteLine("Thread is running...");
        //    Thread.Sleep(2000); // Simulate work
        //    Console.WriteLine("Thread work is done.");
        //}

        //static void Main()
        //{
        //    Task task = Task.Run(() => {
        //        Task.Delay(15000).Wait(); // simulate work
        //        for (int i = 0; i < 5; i++)
        //        {
        //            Console.WriteLine($"Task thread: {i}");
        //            Task.Delay(500); // simulate work
        //        }
        //    });

        //    Console.WriteLine("Main thread continues...");

        //    task.Wait(); // Wait for the task to finish
        //    Console.WriteLine("Task completed.");
        //    Console.ReadKey();
        //}

        static void Main()
        {
            Console.WriteLine($"[Main Thread] Start - {DateTime.Now:HH:mm:ss.fff} - Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            Task task = Task.Run(() =>
            {
                Console.WriteLine($"[Task Thread] Started - {DateTime.Now:HH:mm:ss.fff} - Thread ID: {Thread.CurrentThread.ManagedThreadId}");

                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine($"[Task Thread] Iteration {i} - {DateTime.Now:HH:mm:ss.fff}");
                    Thread.Sleep(1000); // simulate work
                }

                Console.WriteLine($"[Task Thread] Completed - {DateTime.Now:HH:mm:ss.fff}");
            });

            // Main thread doing work in parallel
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"[Main Thread] Iteration {i} - {DateTime.Now:HH:mm:ss.fff}");
                Thread.Sleep(800); // slightly faster than task thread
            }

            task.Wait(); // Wait for task to complete
            Console.WriteLine($"[Main Thread] Task Completed - {DateTime.Now:HH:mm:ss.fff}");
            Console.ReadKey();
        }
    }
}

// multithreading => threads or tasks
// locking => lock, mutex, semaphore

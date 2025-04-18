using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class HouseholdManagementSystem
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Household Management System started.");
            Task t1 = WashAndDryClothes();
            Task t2 = CookDinner();
            Task t3 = CleanHouse();

            await Task.WhenAll(t1, t2, t3);
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Household Management System completed.");
        }

        private static async Task WashAndDryClothes()
        {
            string wetClothes = await WashClothes();
            await DryClothes();
        }

        private static async Task<string> WashClothes()
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Started washing clothes...");
            await Task.Delay(1000); // Simulate washing time
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Finished washing clothes.");
            return "Wet washed.";
        }

        private static async Task DryClothes()
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Started drying clothes...");
            await Task.Delay(1000); // Simulate drying time
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Finished drying clothes.");
        }

        private static async Task CleanHouse()
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Started cleaning house...");
            await Task.Delay(2000); // Simulate cleaning time
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Finished cleaning house.");
        }

        private static async Task CookDinner()
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Started cooking dinner...");
            await Task.Delay(2000); // Simulate cooking time
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Finished cooking dinner.");
        }
    }
}

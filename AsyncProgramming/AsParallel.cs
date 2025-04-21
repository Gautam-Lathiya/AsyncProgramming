using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class AsParallel
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 10000000);

            Stopwatch swSequential = Stopwatch.StartNew();
            var sequentialResult = numbers.Where(n => IsPrime(n)).ToList();
            swSequential.Stop();
            Console.WriteLine($"Sequential Count: {sequentialResult.Count}, Time: {swSequential.ElapsedMilliseconds} ms");

            Stopwatch swParallel = Stopwatch.StartNew();
            var parallelResult = numbers.AsParallel().Where(n => IsPrime(n)).ToList();
            swParallel.Stop();
            Console.WriteLine($"Parallel Count: {parallelResult.Count}, Time: {swParallel.ElapsedMilliseconds} ms");

        }
        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}

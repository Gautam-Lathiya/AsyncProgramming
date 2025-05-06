using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class ProducerConsumer
    {
        private static readonly Queue<int> _buffer = new Queue<int>();
        private const int _maxBufferSize = 5;
        private static readonly object _lock = new object();
        private static int _itemCounter = 1;

        public static void Producer()
        {
            while (true)
            {
                lock (_lock)
                {
                    while (_buffer.Count >= _maxBufferSize)
                    {
                        Console.WriteLine("Producer: Buffer full, waiting...");
                        Monitor.Wait(_lock);
                    }

                    int item = _itemCounter++;
                    _buffer.Enqueue(item);
                    Console.WriteLine($"Producer: Produced item {item}");

                    Monitor.Pulse(_lock); // Wake up consumer
                }

                Thread.Sleep(500); // Simulate production delay
            }
        }

        public static void Consumer()
        {
            while (true)
            {
                int item;
                lock (_lock)
                {
                    while (_buffer.Count == 0)
                    {
                        Console.WriteLine("Consumer: Buffer empty, waiting...");
                        Monitor.Wait(_lock);
                    }

                    item = _buffer.Dequeue();
                    Console.WriteLine($"Consumer: Consumed item {item}");

                    Monitor.Pulse(_lock); // Wake up producer
                }

                Thread.Sleep(800); // Simulate consumption delay
            }
        }

        static void Main()
        {
            Thread producerThread = new Thread(Producer);
            Thread consumerThread = new Thread(Consumer);

            producerThread.Start();
            consumerThread.Start();

            producerThread.Join();
            consumerThread.Join();
        }
    }
}

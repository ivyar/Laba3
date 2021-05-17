using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Consumer:Producer
    {
        public int[] FunctionConsumer()
        {
            int j = 0;
            int[] nums = new int[9];

            FunctionProducer();

            Task consumerThread = Task.Factory.StartNew(() =>
            {
                while (!producers[0].IsCompleted || !producers[1].IsCompleted || !producers[2].IsCompleted)
                {
                    int item;
                    BlockingCollection<int>.TryTakeFromAny(producers, out item, TimeSpan.FromSeconds(1));
                    if (item != default(int))
                    {
                        Console.WriteLine(item);
                        nums[j] = item;
                        j++;
                    }
                }
            });

            return nums;
        }
    }
}

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class ProducerConsumer
    {
        BlockingCollection<int>[] producers = new BlockingCollection<int>[3];
        public ProducerConsumer()
        {
            producers[0] = new BlockingCollection<int>(boundedCapacity: 3);
            producers[1] = new BlockingCollection<int>(boundedCapacity: 3);
            producers[2] = new BlockingCollection<int>(boundedCapacity: 3);
        }

        public int[] Function()
        {
            int j = 0;
            int[] nums = new int[9];

            Task t1 = Task.Factory.StartNew(() =>
            {
                for (int i = 1; i <= 3; ++i)
                {
                    producers[0].Add(i);
                    Thread.Sleep(1000);
                }
                producers[0].CompleteAdding();
            });

            Task t2 = Task.Factory.StartNew(() =>
            {
                for (int i = 4; i <= 6; ++i)
                {
                    producers[1].Add(i);
                    Thread.Sleep(1500);
                }
                producers[1].CompleteAdding();
            });


            Task t3 = Task.Factory.StartNew(() =>
            {
                for (int i = 7; i <= 9; ++i)
                {
                    producers[2].Add(i);
                    Thread.Sleep(1950);
                }
                producers[2].CompleteAdding();
            });

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

            Task.WaitAll(t1, t2, t3, consumerThread);

            return nums;
        }
    }
}

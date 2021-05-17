using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Producer
    {
        public BlockingCollection<int>[] producers = new BlockingCollection<int>[3];
        public Producer()
        {
            producers[0] = new BlockingCollection<int>(boundedCapacity: 3);
            producers[1] = new BlockingCollection<int>(boundedCapacity: 3);
            producers[2] = new BlockingCollection<int>(boundedCapacity: 3);
        }

        public void FunctionProducer()
        {
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

            Task.WaitAll(t1, t2, t3);
        }
    }
}

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Consumer
    {
        public int[] FunctionConsumer()
        {
            var producer = new Producer();

            int[] nums = new int[9];

            Task consumerThread = Task.Factory.StartNew(() => producer.StartProducing(nums));

            return nums;
        }
    }
}

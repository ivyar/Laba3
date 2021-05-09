using ConsoleApp3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace ConsoleApp3_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = new ProducerConsumer();
            Thread.Sleep(1000);
            int[] expected = new int[9];
            expected[0] = 1;
            expected[1] = 4;
            expected[2] = 7;
            expected[3] = 2;
            expected[4] = 5;
            expected[5] = 8;
            expected[6] = 3;
            expected[7] = 6;
            expected[8] = 9;
            Assert.AreEqual(expected, a.Function());
        }
    }
}

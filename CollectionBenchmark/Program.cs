using BenchmarkDotNet.Running;
using System;

namespace CollectionBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MyBenchmark>();
        }
    }
}

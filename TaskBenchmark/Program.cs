using BenchmarkDotNet.Running;
using System;

namespace TaskBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MyTaskBenchmark>();
        }
    }
}

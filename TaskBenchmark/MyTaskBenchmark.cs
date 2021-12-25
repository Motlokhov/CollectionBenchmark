using BenchmarkDotNet.Attributes;
using System;
using System.Threading.Tasks;

namespace TaskBenchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    public class MyTaskBenchmark
    {
        public readonly int TaskCount = 7;

        private async Task<int> SomeAsyncTask(int i)
        {
            await Task.Delay(50);
            return i;
        }

        private async Task CreateAwaitWhenAll(int taskCount)
        {
            Task<int>[] tasks = new Task<int>[taskCount];

            for (int i = 0; i < taskCount; i++)
            {
                tasks[i] = SomeAsyncTask(i);
            }

            await Task.WhenAll(tasks);
        }

        private async Task CreateAwaitEach(int taskCount)
        {
            for (int i = 0; i < taskCount; i++)
            {
                await SomeAsyncTask(i);
            }
        }

        [Benchmark]
        public async Task BenchGroup_1_Await_When_All() => await CreateAwaitWhenAll(TaskCount);

        [Benchmark]
        public async Task BenchGroup_1_Await_Each() => await CreateAwaitEach(TaskCount);
    }
}

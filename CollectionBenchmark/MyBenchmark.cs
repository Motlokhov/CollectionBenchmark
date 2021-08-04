using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace CollectionBenchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    public class MyBenchmark
    {
        private readonly int size = 100;
        public MyBenchmark()
        {
        }

        public int[] CreateArray(int size)
        {
            int[] array = new int[size];
            for(int i = 0; i < array.Length; i++)
                array[i] = i;
            return array;
        }

        public List<int> CreateList(int size)
        {
            List<int> list = new List<int>(size);
            for(int i = 0; i < list.Count; i++)
                list[i] = i;
            return list;
        }

        [Benchmark]
        public int For_List_NoElementAt()
        {
            List<int> _list = CreateList(size);
            int take = 0;
            for(int i = 0; i < _list.Count; i++)
                take = _list[i];
            return take;
        }

        [Benchmark]
        public int For_List_ElementAt()
        {
            List<int> _list = CreateList(size);
            int take = 0;
            for(int i = 0; i < _list.Count; i++)
                take = _list.ElementAt(i);
            return take;
        }

        [Benchmark]
        public int For_Array_NoElementAt()
        {
            int[] _array = CreateArray(size);
            int take = 0;
            for(int i = 0; i < _array.Length; i++)
                take = _array[i];
            return take;
        }

        [Benchmark]
        public int For_Array_ElementAt()
        {
            int[] _array = CreateArray(size);
            int take = 0;
            for(int i = 0; i < _array.Length; i++)
                take = _array.ElementAt(i);
            return take;
        }

        [Benchmark]
        public int Foreach_Array()
        {
            int[] _array = CreateArray(size);
            int take = 0;
            foreach(int item in _array)
                take = item;
            return take;
        }

        [Benchmark]
        public int Foreach_List()
        {
            List<int> _list = CreateList(size);
            int take = 0;
            foreach(int item in _list)
                take = item;
            return take;
        }

        [Benchmark]
        public int For_ArrayAsEnumerable_ElementAt()
        {
            return ForEnumerable(CreateArray(size));
        }

        [Benchmark]
        public int For_ListAsEnumerable_ElementAt()
        {
            return ForEnumerable(CreateList(size));
        }

        [Benchmark]
        public int ForEach_ArrayAsEnumerable()
        {
            return ForeachEnumerable(CreateArray(size));
        }

        [Benchmark]
        public int ForEach_ListAsEnumerable()
        {
            return ForeachEnumerable(CreateList(size));
        }

        private int ForEnumerable(IEnumerable<int> en)
        {
            int take = 0;
            for(int i = 0; i < en.Count(); i++)
                take = en.ElementAt(i);
            return take;
        }

        private int ForeachEnumerable(IEnumerable<int> en)
        {
            int take = 0;
            foreach(int item in en)
                take = item;
            return take;
        }
    }
}

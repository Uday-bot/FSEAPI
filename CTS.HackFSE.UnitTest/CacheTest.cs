using NBench;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSEFinalTaskUnitTest
{
    public class CacheTest
    {
        private SimpleCache<string> cache = new SimpleCache<string>();

       private SimpleCacheDict<string> cacheD = new SimpleCacheDict<string>();

        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Measurement,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]
        public void Add_Benchmark_Performance()
        {
            for (var i = 0; i < 100000; i++)
            {
                cache.Add(i.ToString());
            }
        }

        [PerfBenchmark(NumberOfIterations = 1,
          RunMode = RunMode.Throughput,
          TestMode = TestMode.Measurement,
          SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]
        public void Add_Benchmark_PerformanceD()
        {
            for (var i = 0; i < 100000; i++)
            {
                cacheD.Add(i.ToString());
            }
        }
    }
}

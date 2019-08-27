using CTS.HackFSE.Business.Interfaces;
using CTS.HackFSE.Service.Controllers;
using CTS.HackFSE.UnitTest.Moq;
using Moq;
using NBench;

namespace CTS.HackFSE.LoadTest
{
    public class PTSpecs
    {

        private Counter _counter;
        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _counter = context.GetCounter("TestCounter");
        }

        [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.", NumberOfIterations = 3, RunMode = RunMode.Throughput,
                                RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.LessThanOrEqualTo, 10000000)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, 2000000)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        public void Benchmark()
        {
            GetProjectsById_OkTest();
            _counter.Increment();
        }

        public void GetProjectsById_OkTest()
        {
            int projectid = 1;

            var output = ProjectControllerMock.GetProject();

            ////Get Mock Repository object
            var ProjectRepositoryMock = new Mock<IProjectBO>();

            //Setup mock object and return mock output
            ProjectRepositoryMock
               .Setup(m => m.GetById(It.IsAny<int>()))
               .Returns(output);

            //Invoke controller method
            ProjectController controller = new ProjectController(ProjectRepositoryMock.Object);

            var value = controller.GetByProjectId(projectid);

        }

        [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.", NumberOfIterations = 2, RunMode = RunMode.Throughput,
                             RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.LessThanOrEqualTo, 10000000)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, 3000000)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]

        public void GetUserByName_OkTest()
        {
            string name = "Satheesh";
            var output = UserControllerMock.GetUsersByName(name);

            //Get Mock Repository object
            var userRepositoryMock = new Mock<IUserInfoBO>();

            //Setup mock object and return mock output
            userRepositoryMock
               .Setup(m => m.GetAllUser("", name))
               .Returns(output);            

            //Invoke controller method
            UserController controller = new UserController(userRepositoryMock.Object);

            var value = controller.Get(name, "");
        }

    }
}

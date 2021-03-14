using CommandLineTools;
using Moq;
using NUnit.Framework;

namespace CommandLineToolsTests
{
    [TestFixture]
    public class FakeApplicationTests
    {
        [Test]
        public void Main_WhenPassedCorrectArgs_CallsRunnerWithAllParams()
        {
            var loggingVal = true;
            var categoryVal = "foo";
            var portVal = 8080;
            var args = new string[] {"-l", "-c", categoryVal, "-p", portVal.ToString()};
            Mock<IRunner> runner = new Mock<IRunner>();
            var app = new FakeApplication(runner.Object);
            app.Main(args);
            runner.Verify(mockedRunner => mockedRunner.RunApplication(loggingVal, categoryVal, portVal));
        }
        
        [Test]
        public void Main_WhenPassedCorrectArgsInDifferentOrder_CallsRunnerWithAllParams()
        {
            var loggingVal = true;
            var categoryVal = "foo";
            var portVal = 8080;
            var args = new string[] {"-c", categoryVal, "-p", portVal.ToString(), "-l"};
            Mock<IRunner> runner = new Mock<IRunner>();
            var app = new FakeApplication(runner.Object);
            app.Main(args);
            runner.Verify(mockedRunner => mockedRunner.RunApplication(loggingVal, categoryVal, portVal));
        }
        
        [Test]
        public void Main_WhenPassedMissingOptionalArgs_CallsRunnerWithAllParams()
        {
            var loggingVal = false;
            var categoryVal = "foo";
            var portVal = 8080;
            var args = new string[] {"-c", categoryVal, "-p", portVal.ToString()};
            Mock<IRunner> runner = new Mock<IRunner>();
            var app = new FakeApplication(runner.Object);
            app.Main(args);
            runner.Verify(mockedRunner => mockedRunner.RunApplication(loggingVal, categoryVal, portVal));
        }
    }
}
using System;
using System.Runtime.InteropServices;
using Moq;

namespace CommandLineTools
{
    public class FakeApplication
    {
        private readonly IRunner _runner;

        public FakeApplication(IRunner runner)
        {
            _runner = runner;
        }

        public void Main(string[] args)
        {
            var parsedArguments = Parser.Parse(args);
            var loggingArg = new BooleanArgument("-l");
            var categoryArg = new StringArgument("-c");
            var portArg = new IntegerArgument("-p");

            var logging = loggingArg.GetBooleanValue(parsedArguments);
            var category = categoryArg.GetStringValue(parsedArguments);
            var port = portArg.GetIntegerValue(parsedArguments);
            _runner.RunApplication(logging, category, port);
        }

        private static void Run(bool logging, string category)
        {
            Console.WriteLine($"Logging: {logging} and Category: {category}");
        }
    }
}
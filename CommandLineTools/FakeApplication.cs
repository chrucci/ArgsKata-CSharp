using System;
using System.Runtime.InteropServices;

namespace CommandLineTools
{
    public class FakeApplication
    {
        public static void Main(string[] args)
        {
            var parsedArguments = Parser.Parse(args);
            var loggingArg = new BooleanArgument("-l");
            var categoryArg = new StringArgument("-c");

            var logging = loggingArg.GetBooleanValue(parsedArguments);
            var category = categoryArg.GetStringValue(parsedArguments);
            Run(logging, category);
        }

        private static void Run(bool logging, string category)
        {
            Console.WriteLine($"Logging: {logging} and Category: {category}");
        }
    }
}
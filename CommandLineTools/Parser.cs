using System.Collections.Generic;
using System.Linq;

namespace CommandLineTools
{
    public static class Parser
    {
        private const string ArgPrefix = "-";

        public static Dictionary<string, string> Parse(string[] args)
        {
            var parsedArguments = new Dictionary<string, string>( );
            string flag;
            string value;

            for (int i = 0; i < args.Length; i++)
            {
                var arg = args[i];
                if (IsFlag(arg))
                {
                    flag = arg;
                    var nextArg = GetNextArg(args, i);
                    value = IsFlag(nextArg) ? null : nextArg;
                    parsedArguments.Add(flag, value);
                }
            }
            
            return parsedArguments;
        }

        private static string GetNextArg(string[] args, int i)
        {
            var nextIndex = i + 1;
            if (args.Length <= nextIndex) return null;
            return args[nextIndex];
        }

        private static bool IsFlag(string arg)
        {
            if (arg is null) return false;
            return arg.StartsWith(ArgPrefix);
        }
    }
}
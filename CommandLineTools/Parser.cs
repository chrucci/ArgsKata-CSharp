using System.Collections.Generic;
using System.Linq;

namespace CommandLineTools
{
    public class Parser
    {
        // private readonly string _args;
        private const string ArgPrefix = "-";
        // private Dictionary<string, string> parsedArguments;

        // public Parser(string[] args)
        // {
        //     _args = args;
        //     this.parsedArguments = Parse(args);
        // }

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

        //
        // public bool GetBooleanValue(BooleanArgument arg)
        // {
        //     return (_args.Contains(ArgPrefix + arg.ArgFlag));
        // }
        //
        // public string GetStringValue(IStringArgument arg)
        // {
        //     return "foo";
        // }
    }
}
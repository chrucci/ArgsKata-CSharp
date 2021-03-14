using System.Linq;

namespace CommandLineTools
{
    public class Parser
    {
        private readonly string _args;
        private const string ArgPrefix = "-";

        public Parser(string args)
        {
            _args = args;
        }

        public bool GetBooleanValue(BooleanArgument arg)
        {
            return (_args.Contains(ArgPrefix + arg.ArgFlag));
        }

        public string GetStringValue(IStringArgument arg)
        {
            return "foo";
        }
    }
}
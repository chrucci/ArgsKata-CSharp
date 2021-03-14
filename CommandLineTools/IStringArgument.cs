using System.Collections.Generic;

namespace CommandLineTools
{
    public interface IStringArgument
    {
        public string GetStringValue(Dictionary<string, string> argDictionary);
    }
}
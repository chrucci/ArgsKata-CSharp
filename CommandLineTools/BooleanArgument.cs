using System.Collections.Generic;

namespace CommandLineTools
{
    public class BooleanArgument
    {
        public string ArgFlag { get; }

        public BooleanArgument(string argFlag)
        {
            ArgFlag = argFlag;
        }


        public bool? GetBooleanValue(Dictionary<string,string> parsedArgs)
        {
            return parsedArgs.ContainsKey(ArgFlag);
        }
    }
}
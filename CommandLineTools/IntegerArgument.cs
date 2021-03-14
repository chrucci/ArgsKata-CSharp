using System.Collections.Generic;

namespace CommandLineTools
{
    public class IntegerArgument
    {
        private readonly string _flag;
        private readonly bool _isMandatory;
        private readonly int _defaultValue;

        public IntegerArgument(string flag, bool isMandatory)
        {
            _flag = flag;
            _isMandatory = isMandatory;
        }
        public IntegerArgument(string flag, int defaultValue = 0) : this(flag, false)
        {
            _defaultValue = defaultValue;
        }

        public int GetIntegerValue(Dictionary<string, string> parsedArguments)
        {
            if (_isMandatory && !parsedArguments.ContainsKey(_flag))
                throw new InvalidArgumentException(_flag);

            int returnVal = _defaultValue;
            if (parsedArguments.ContainsKey(_flag))
            {
                var testValue = parsedArguments[_flag];
                if (!int.TryParse(testValue, out returnVal))
                    throw new InvalidIntegerArgumentException(_flag, testValue);
            }
            
            return  returnVal;
        }
    }
}
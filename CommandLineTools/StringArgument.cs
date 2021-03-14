using System;
using System.Collections.Generic;

namespace CommandLineTools
{
    public class StringArgument 
    {
        private readonly bool _isMandatory;
        private readonly string _flag;
        private readonly string _defaultValue;

        public StringArgument(string flag, bool isMandatory)
        {
            _flag = flag;
            _isMandatory = isMandatory;
        }

        public StringArgument(string flag, string defaultValue = "") : this(flag, false)
        {
            _defaultValue = defaultValue;
        }

        public string GetStringValue(Dictionary<string, string> argDictionary)
        {
            var returnVal = _defaultValue;
            if (argDictionary.ContainsKey(_flag))
                returnVal = argDictionary[_flag];
            else if (_isMandatory)
                throw new InvalidArgumentException(_flag);
            return returnVal;
        }
    }
}
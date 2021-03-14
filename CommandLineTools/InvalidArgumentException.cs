using System;

namespace CommandLineTools
{
    public class InvalidArgumentException : ApplicationException
    {
        public InvalidArgumentException(char flagName):base($"Flag '{flagName}' must be included in the list of arguments.")
        {
        }
    }
}
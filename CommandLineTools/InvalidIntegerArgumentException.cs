using System;

namespace CommandLineTools
{
    public class InvalidIntegerArgumentException : ApplicationException
    {
        public InvalidIntegerArgumentException(string flagName, string argumentValue):base($"Value {argumentValue} for flag {flagName} must be an integer.")
        {
        }
    }
}
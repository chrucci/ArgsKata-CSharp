using System;

namespace CommandLineTools
{
    public interface IArgFlag
    {
        public string Name { get; }
        public string ToString();
    }
}
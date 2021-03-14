using System;
using System.Collections.Generic;
using CommandLineTools;
using NUnit.Framework;

namespace CommandLineToolsTests
{
    [TestFixture]
    public class StringArgumentTests
    {
        [Test]
        public void GetStringValue_WithDictionaryWithMatchArg_ReturnsValue()
        {
            var expected = "foo";
            var flag = "-c";
            var arg = new StringArgument(flag);
            var parsedArguments = new Dictionary<string, string> {{flag, expected}};

            Assert.AreEqual(expected, arg.GetStringValue(parsedArguments));
        }
        
        [Test]
        public void GetStringValue_WithDictionaryWithNoMatchArg_ReturnsDefaultValue()
        {
            var expected = "foo";
            var flag = "-c";
            var arg = new StringArgument(flag, expected);
            var parsedArguments = new Dictionary<string, string>();
            
            Assert.AreEqual(expected, arg.GetStringValue(parsedArguments));
        }
        
        [Test]
        public void GetStringValue_WithDictionaryWithNoMatchMandatoryArg_ThrowsException()
        {
            var flag = "-c";
            var arg = new StringArgument(flag, true);
            var parsedArguments = new Dictionary<string, string>();
            
            Assert.Throws<InvalidArgumentException>(() => arg.GetStringValue(parsedArguments));
        }
    }
}
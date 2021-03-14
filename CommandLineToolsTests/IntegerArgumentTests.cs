using System;
using System.Collections.Generic;
using CommandLineTools;
using NUnit.Framework;

namespace CommandLineToolsTests
{
    [TestFixture]
    public class IntegerArgumentTests
    {
        [TestCase("8080")]
        [TestCase("80")]
        public void GetIntegerValue_WithDictionaryOfMatchingFlag_ReturnsCorrespondingValue(string value)
        {
            var flag = "-p";
            var parsedArguments = new Dictionary<string, string>() {{flag, value}};

            var intArg = new IntegerArgument(flag);
            
            Assert.AreEqual(int.Parse(value), intArg.GetIntegerValue(parsedArguments));
        }
        
        [Test]
        public void GetIntegerValue_WithDictionaryOfMatchingFlagButNonIntegerValue_ThrowException()
        {
            var flag = "-p";
            var value = "foo";
            var parsedArguments = new Dictionary<string, string>() {{flag, value}};

            var intArg = new IntegerArgument(flag);
            
            var ex = Assert.Throws<InvalidIntegerArgumentException>(() => intArg.GetIntegerValue(parsedArguments)); 
            Assert.AreEqual($"Value {value} for flag {flag} must be an integer.", ex.Message);
        }

        [Test]
        public void GetIntegerValue_WithoutMatchingValue_ReturnsDefaultValue()
        {
            var flag = "-p";
            var defaultValue = 0;
            var parsedArguments = new Dictionary<string, string>();

            var intArg = new IntegerArgument(flag);
            
            Assert.AreEqual(defaultValue, intArg.GetIntegerValue(parsedArguments));
        }

        [Test]
        public void GetIntegerValue_WithoutMatchingValue_ReturnsOverridenDefaultValue()
        {
            var flag = "-p";
            var defaultValue = 80;
            var parsedArguments = new Dictionary<string, string>();

            var intArg = new IntegerArgument(flag, defaultValue);
            
            Assert.AreEqual(defaultValue, intArg.GetIntegerValue(parsedArguments));
        }
        
        [Test]
        public void GetIntegerValue_WithDictionaryWithNoMatchMandatoryArg_ThrowsException()
        {
            var flag = "-p";
            var arg = new IntegerArgument(flag, true);
            var parsedArguments = new Dictionary<string, string>();
            
            Assert.Throws<InvalidArgumentException>(() => arg.GetIntegerValue(parsedArguments));
        }
    }
}
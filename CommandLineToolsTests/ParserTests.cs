using CommandLineTools;
using NUnit.Framework;

namespace CommandLineToolsTests
{
    public class ParserTests
    {

        [Test]
        public void Parse_WithOneBooleanSchemaAndArg_ReturnsFlagAndNull()
        {
            var flag = "-l";
            string[] args = {flag};
            var parsedArguments = Parser.Parse(args);
            
            Assert.AreEqual(1,parsedArguments.Count); 
            Assert.IsNull(parsedArguments[flag]); 
        }

        [Test]
        public void Parse_WithTwoBooleanSchemaAndArg_ReturnsFlagsAndNulls()
        {
            var flag1 = "-l";
            var flag2 = "-a";
            string[] args = {flag1, flag2};
            var parsedArguments = Parser.Parse(args);
            
            Assert.AreEqual(2,parsedArguments.Count); 
            Assert.IsNull(parsedArguments[flag1]); 
            Assert.IsNull(parsedArguments[flag2]); 
        }

        [Test]
        public void Parse_WithOneSchemaAndArg_ReturnsFlagAndStringValue()
        {
            var flag = "-l";
            var value = "foo";
            string[] args = {flag, value};
            var parsedArguments = Parser.Parse(args);
            
            Assert.AreEqual(1,parsedArguments.Count); 
            Assert.AreEqual(value, parsedArguments[flag]); 
        }

        [Test]
        public void Parse_WithTwoStringSchemaAndArg_ReturnsFlagsAndValues()
        {
            var flag1 = "-l";
            var value1 = "bar";
            var flag2 = "-a";
            var value2 = "baz";
            string[] args = {flag1, value1, flag2, value2};
            var parsedArguments = Parser.Parse(args);
            
            Assert.AreEqual(2,parsedArguments.Count); 
            Assert.AreEqual(value1, parsedArguments[flag1]); 
            Assert.AreEqual(value2, parsedArguments[flag2]); 
        }

        [Test]
        public void Parse_WithOneBooleanAndStringArg_ReturnsParsedFlagsAndValues()
        {
            var flag1 = "-l";
            var flag2 = "-a";
            var value2 = "baz";
            string[] args = {flag1, flag2, value2};
            var parsedArguments = Parser.Parse(args);
            
            Assert.AreEqual(2,parsedArguments.Count); 
            Assert.IsNull( parsedArguments[flag1]); 
            Assert.AreEqual(value2, parsedArguments[flag2]); 
            
        }

        [Test]
        public void Parse_WithOneStringAndBooleanArg_ReturnsParsedFlagsAndValues()
        {
            var flag2 = "-l";
            var flag1 = "-a";
            var value1 = "baz";
            string[] args = {flag1, value1, flag2};
            var parsedArguments = Parser.Parse(args);

            Assert.AreEqual(2, parsedArguments.Count);
            Assert.AreEqual(value1, parsedArguments[flag1]);
            Assert.IsNull(parsedArguments[flag2]);
        }
    }
}
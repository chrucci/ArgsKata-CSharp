using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using CommandLineTools;
using NUnit.Framework;
using Moq;

namespace CommandLineToolsTests
{
    public class ParserTests
    {

        [Test]
        public void GetBoolean_WithOneBooleanSchemaAndArg_True()
        {
            var args = "-l";
            var loggingArg = new BooleanArgument("l");
            var parser = new Parser(args);
            var loggingVal = parser.GetBooleanValue(loggingArg);
            
            Assert.IsTrue(loggingVal);
        }

        [Test]
        public void GetBoolean_WithOneBooleanSchemaAndMissingArg_False()
        {
            var args = "";
            var loggingArg = new BooleanArgument("l");
            var parser = new Parser(args);
            var loggingVal = parser.GetBooleanValue(loggingArg);
            
            Assert.IsFalse(loggingVal);
        }

        [Test]
        public void GetString_WithOneStringValue_ReturnsStringValue()
        {
            var expected = "foo";
            var args = "-c ${expected}";
            var parser = new Parser(args);
            var categoryArg = new StringArgument("c");
            var categoryValue = parser.GetStringValue(categoryArg);

            Assert.AreEqual(expected, categoryValue);
        }

        [Test]
        [Ignore("WIP")]
        public void GetString_WithNoStringValue_ReturnsDefaultStringValue()
        {
            var expected = "bar";
            var args = "";
            var parser = new Parser(args);
            var categoryArg = new StringArgument("c", expected);
            var categoryValue = parser.GetStringValue(categoryArg);

            Assert.AreEqual(expected, categoryValue);
        }
    }
}
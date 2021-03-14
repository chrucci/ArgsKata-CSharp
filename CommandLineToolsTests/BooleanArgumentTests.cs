using System;
using System.Collections.Generic;
using CommandLineTools;
using NUnit.Framework;

namespace CommandLineToolsTests
{
    [TestFixture]
    public class BooleanArgumentTests
    {

        [Test]
        public void GetBooleanValue_WhenArgIsPresent_ReturnsTrue()
        {
            var flag = "-l";
            var arg = new BooleanArgument(flag);
            var parsedArgs = new Dictionary<string, string> {{flag, null}};

            Assert.IsTrue(arg.GetBooleanValue(parsedArgs));
        }

        [Test]
        public void GetBooleanValue_WhenArgIsNotPresent_ReturnsFalse()
        {
            var flag = "-l";
            var arg = new BooleanArgument(flag);
            var parsedArgs = new Dictionary<string, string>();
            
            Assert.IsFalse(arg.GetBooleanValue(parsedArgs));
        }
        
        
    }
}
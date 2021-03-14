using System;
using CommandLineTools;
using NUnit.Framework;

namespace CommandLineToolsTests
{
    [TestFixture]
    public class ArgumentTests
    {

        [Test]
        public void isValid_WhenEmptyArgRegistered_ReturnTrue()
        {
            var arg = new Argument('l');
            arg.Register();
            
            Assert.IsTrue(arg.IsValid());
        }
        
        [Test]
        public void isValid_WhenEmptyArgNotFound_ReturnFalse()
        {
            var arg = new Argument('l');
            
            Assert.IsFalse(arg.IsValid());
        }
        
        
    }
}
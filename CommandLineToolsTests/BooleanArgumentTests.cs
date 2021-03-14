using System;
using CommandLineTools;
using NUnit.Framework;

namespace CommandLineToolsTests
{
    [TestFixture]
    public class BooleanArgumentTests
    {

        [Test]
        public void IsValid_WhenEmptyArgRegistered_ReturnTrue()
        {
            var arg = new BooleanArgument('l');
            arg.Register();
            
            Assert.IsTrue(arg.IsValid());
        }
        
        [Test]
        public void IsValid_WhenMandatoryEmptyArgNotFound_ThrowsExceptionWithHelpfulErrorMessage()
        {
            var flagName = 'l';
            var arg = new BooleanArgument('l', true);
            
            Assert.Throws<InvalidArgumentException>(() => arg.IsValid(), "Flag 'l' must be included in the list of arguments.");
        }

        [Test]
        public void Value_WhenNoneProvided_ReturnsDefault()
        {
            var arg = new BooleanArgument('l');
            
            Assert.IsTrue(arg.Value);
        }

        [Test]
        public void Value_WithDefaultOverriden_ReturnsDefault()
        {
            var arg = new BooleanArgument('l');
            arg.Value = false;
            
            Assert.IsFalse(arg.Value);
        }

        [Test]
        public void GetErrorMessage_WhenMandatoryAndNotValid_ReturnsMessage()
        {
            var arg = new BooleanArgument('l', true);
        }
        
        
    }
}
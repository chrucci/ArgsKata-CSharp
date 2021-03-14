using CommandLineTools;
using NUnit.Framework;

namespace CommandLineToolsTests
{
    [TestFixture]
    public class InvalidIntegerArgumentExceptionTests
    {
        

        [Test]
        public void Throws_WhenPassedFlagAndValue_DisplaysMessage()
        {
            var flag = "foo";
            var value = "bar";
            var ex = new InvalidIntegerArgumentException(flag, value);
            
            Assert.AreEqual($"Value {value} for flag {flag} must be an integer.", ex.Message);
        }

    }
}
using CommandLineTools;
using NUnit.Framework;

namespace CommandLineToolsTests
{
    [TestFixture]
    public class InvalidArgumentExceptionTests
    {
        [Test]
        public void Throws_WhenCalled_CreateMessage()
        {
            var flag = "foo";
            var ex = new InvalidArgumentException(flag);
            
            Assert.AreEqual($"Flag '{flag}' must be included in the list of arguments.", ex.Message);
        }
    }
}
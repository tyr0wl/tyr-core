using System;
using Xunit;
using tyr.Core.Extensions;

namespace tyr.Core.Tests
{
    public class StringExtensionTests
    {
        [Fact]
        public void Should_not_throw_on_null()
        {
            // Arrange
            string nullString = null;

            // Act
            var actual = nullString.Contains("test", StringComparison.OrdinalIgnoreCase);

            // 
            Assert.True(false == actual);
        }
    }
}

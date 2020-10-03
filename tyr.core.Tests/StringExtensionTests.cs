using System;
using Xunit;
using tyr.Core.Extensions;

namespace tyr.Core.Tests
{
    public class StringExtensionTests
    {
        [Fact]
        public void Should_throw_when_source_is_null()
        {
            // Arrange
            string nullString = null;

            // Act
            void Action() => nullString.Contains("test", StringComparison.OrdinalIgnoreCase);

            // Assert
            Assert.Throws<ArgumentNullException>(Action);
        }

        [Fact]
        public void Should_throw_when_value_is_null()
        {
            // Arrange
            const string value = "test";

            // Act
            void Action() => value.Contains(null, StringComparison.OrdinalIgnoreCase);

            // Assert
            Assert.Throws<ArgumentNullException>(Action);
        }

        [Fact]
        public void Should_match_string_empty()
        {
            // Arrange
            string value = string.Empty;

            // Act
            var actual = value.Contains(string.Empty, StringComparison.OrdinalIgnoreCase);

            // 
            Assert.True(actual);
        }

        [Fact]
        public void Should_match_value_on_full_string_with_current_culture()
        {
            // Arrange
            const string value = "test";

            // Act
            var actual = value.Contains("test", StringComparison.CurrentCulture);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void Should_not_match_value_on_full_string_with_current_culture_and_different_case()
        {
            // Arrange
            const string value = "tEst";

            // Act
            var actual = value.Contains("test", StringComparison.CurrentCulture);

            // Assert
            Assert.True(false == actual);
        }

        [Fact]
        public void Should_match_value_on_full_string_with_ignore_case_and_different_case()
        {
            // Arrange
            const string value = "tEst";

            // Act
            var actual = value.Contains("test", StringComparison.InvariantCultureIgnoreCase);

            // Assert
            Assert.True(actual);
        }
    }
}

using Pokedex.Library.Utilities;

namespace Pokedex.Library.UnitTest
{
    public class StringCleanerTest
    {
        [Theory]
        [InlineData("This is a test string\n", "This is a test string ")]
        [InlineData("This is a test string\f", "This is a test string ")]
        [InlineData("This is a test string\r", "This is a test string ")]
        [InlineData("This is a test string\t", "This is a test string ")]
        public void RemoveEscapeSequencesTest(string input, string expected)
        {
            // Arrange
            string actual;

            // Act
            actual = StringCleaner.RemoveEscapeSequences(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}

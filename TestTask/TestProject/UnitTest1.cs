using FizzBuzz;

namespace TestProject
{
    public class UnitTest1
    {
        private readonly FizzBuzzDetector _detector = new FizzBuzzDetector();

        // Test 1: exact example from the spec
        [Fact]
        public void GetOverlappings_ReturnsCorrectOutput_ForSpecExample()
        {
            string input = "Mary had a little lamb\nLittle lamb, little lamb\nMary had a little lamb\nIt's fleece was white as snow";

            var result = _detector.GetOverlappings(input);

            Assert.Equal("Mary had Fizz little Buzz\nFizz lamb, little Fizz\nBuzz had Fizz little lamb\nFizzBuzz fleece was Fizz as Buzz", result.OutputString);
            Assert.Equal(9, result.Count);
        }

        // Test 2: null input should throw ArgumentNullException
        [Fact]
        public void GetOverlappings_ThrowsArgumentNullException_WhenInputIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _detector.GetOverlappings(null));
        }

        // Test 3: input too short should throw ArgumentOutOfRangeException
        [Fact]
        public void GetOverlappings_ThrowsArgumentOutOfRangeException_WhenInputTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _detector.GetOverlappings("hello"));
        }

        // Test 4: input too long should throw ArgumentOutOfRangeException
        [Fact]
        public void GetOverlappings_ThrowsArgumentOutOfRangeException_WhenInputTooLong()
        {
            string longInput = new string('a', 101);
            Assert.Throws<ArgumentOutOfRangeException>(() => _detector.GetOverlappings(longInput));
        }

        // Test 5: non-alphanumeric tokens are preserved but skipped in count
        [Fact]
        public void GetOverlappings_PreservesNonAlphanumericTokens()
        {
            var result = _detector.GetOverlappings("Mary had a little lamb!!");

            Assert.Equal("Mary had Fizz little Buzz!!", result.OutputString);
        }

        // Test 6: every 15th word should be FizzBuzz and count as 1
        [Fact]
        public void GetOverlappings_ReplacesFifteenthWord_WithFizzBuzz()
        {
            string input = "a b c d e f g h i j k l m n o";

            var result = _detector.GetOverlappings(input);

            Assert.Contains("FizzBuzz", result.OutputString);
        }
    }
}
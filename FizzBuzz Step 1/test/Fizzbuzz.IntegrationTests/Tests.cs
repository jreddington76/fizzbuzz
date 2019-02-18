using System;
using Xunit;

namespace FizzBuzz.IntegrationTests
{
    public class Tests
    {
        [Fact]
        public void Constructor_WithNullArg_ShouldThrowArgumentException()
        {
            // arrange

            // act
            var exception = Assert.Throws<ArgumentException>(() => new Controller(null));

            // assert
            Assert.Equal("numberEvaluator", exception.Message);
        }

        [Fact]
        public void Run_WithRangeLessThanOrEqualToOne_ShouldThrowArgumentException()
        {
            // arrange
            var controller = new Controller(new NumberEvaluator());
            var range = 0;

            // act
            var exception = Assert.Throws<ArgumentException>(() => controller.Run(range));

            // assert
            Assert.Equal("Range should be greater than 1", exception.Message);
        }

        [Fact]
        public void Run_Range20_ShouldOutputResults()
        {
            // arrange
            var controller = new Controller(new NumberEvaluator());
            var range = 20;

            // act
            var results = controller.Run(range);

            // assert
            Assert.Equal("1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz 16 17 fizz 19 buzz", results);
        }
    }
}

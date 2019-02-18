using System;
using System.Collections.Generic;
using Xunit;

namespace FizzBuzz
{
    public class SummaryTests
    {
        private readonly Summary _summary;

        public SummaryTests()
        {
            _summary = new Summary();
        }

        [Theory]
        [InlineData(null)]
        [InlineData()]
        public void GetResults_WithNullInput_ShouldReturnEmptyResults(params string[] input)
        {
            // arrange

            // act
            var result = _summary.GetResults(input);

            // assert
            Assert.Equal("fizz: 0 buzz: 0 fizzbuzz: 0 lucky: 0 integer: 0", result);
        }

        [Fact]
        public void GetResults_NumberContainsAThree_ShouldReturnLucky()
        {
            // arrange
            var input = new List<string>() { "1", "2", "lucky", "4", "buzz", "fizz", "7", "8", "fizz", "buzz", "lucky", "14", "fizzbuzz" };

            // act
            var result = _summary.GetResults(input);

            // assert
            Assert.Equal("fizz: 2 buzz: 2 fizzbuzz: 1 lucky: 2 integer: 6", result);
        }
    }
}
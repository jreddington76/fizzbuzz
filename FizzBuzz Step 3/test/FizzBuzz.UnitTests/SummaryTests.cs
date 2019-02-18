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
            var input = new List<string>() { "1", "2", "lucky", "4", "buzz" };

            // act
            var result = _summary.GetResults(input);

            // assert
            Assert.Equal("fizz: 0 buzz: 1 fizzbuzz: 0 lucky: 1 integer: 3", result);
        }
    }
}
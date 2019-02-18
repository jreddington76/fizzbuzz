using System;
using FizzBuzz.Interfaces;
using Moq;
using Xunit;

namespace FizzBuzz
{
    public class ControllerTests
    {
        private readonly Mock<INumberEvaluator> _numberEvaluator;
        private readonly Controller _controller;

        public ControllerTests()
        {
            _numberEvaluator = new Mock<INumberEvaluator>();
            _controller = new Controller(_numberEvaluator.Object);
        }

        [Fact]
        public void Constructor_WithNullArg_ShouldThrowArgumentException()
        {
            // arrange

            // act
            var exception = Assert.Throws<ArgumentException>(() => new Controller(null));

            // assert
            Assert.Equal("numberEvaluator", exception.Message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void Run_WithRangeLessThanOrEqualToOne_ShouldThrowArgumentException(int range)
        {
            // arrange

            // act
            var exception = Assert.Throws<ArgumentException>(() => _controller.Run(range));

            // assert
            Assert.Equal("Range should be greater than 1", exception.Message);
        }

        [Fact]
        public void Run_WithValidRange_ShouldOutputResultsWithSpaceBetween()
        {
            // arrange
            var range = 5;
            _numberEvaluator.SetupSequence(x => x.Resolve(It.IsAny<int>()))
              .Returns("1")
              .Returns("2")
              .Returns("fizz")
              .Returns("4")
              .Returns("buzz");

            // act
            var results = _controller.Run(range);

            // assert
            _numberEvaluator.VerifyAll();
            Assert.Equal("1 2 fizz 4 buzz", results);
        }
    }
}
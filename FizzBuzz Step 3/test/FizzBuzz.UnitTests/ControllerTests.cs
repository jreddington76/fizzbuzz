using System;
using System.Collections.Generic;
using FizzBuzz.Interfaces;
using Moq;
using Xunit;

namespace FizzBuzz
{
    public class ControllerTests
    {
        private readonly Mock<INumberEvaluator> _numberEvaluator;
        private readonly Mock<ISummary> _summary;
        private readonly Controller _controller;

        public ControllerTests()
        {
            _numberEvaluator = new Mock<INumberEvaluator>();
            _summary = new Mock<ISummary>();

            _controller = new Controller(_numberEvaluator.Object, _summary.Object);
        }

        [Fact]
        public void Constructor_WithNullNumberEvaluator_ShouldThrowArgumentException()
        {
            // arrange

            // act
            var exception = Assert.Throws<ArgumentException>(() => new Controller(null, _summary.Object));

            // assert
            Assert.Equal("numberEvaluator", exception.Message);
        }

        [Fact]
        public void Constructor_WithNullSummary_ShouldThrowArgumentException()
        {
            // arrange

            // act
            var exception = Assert.Throws<ArgumentException>(() => new Controller(_numberEvaluator.Object, null));

            // assert
            Assert.Equal("summary", exception.Message);
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
        public void Run_WithValidRange_ShouldOutputResultsAndSummary()
        {
            // arrange
            var range = 5;

            _numberEvaluator.SetupSequence(x => x.Resolve(It.IsAny<int>()))
              .Returns("1")
              .Returns("2")
              .Returns("lucky")
              .Returns("4")
              .Returns("buzz");

            _summary.Setup(x => x.GetResults(It.IsAny<List<string>>())).Returns("fizz: 0 buzz: 1 fizzbuzz: 0 lucky: 1 integer: 3");

            // act
            var results = _controller.Run(range);

            // assert
            _numberEvaluator.VerifyAll();
            _summary.VerifyAll();
            Assert.Equal("1 2 lucky 4 buzz fizz: 0 buzz: 1 fizzbuzz: 0 lucky: 1 integer: 3", results);
        }
    }
}
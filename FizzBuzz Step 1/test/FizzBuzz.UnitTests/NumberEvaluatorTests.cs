using System;
using Xunit;

namespace FizzBuzz
{
    public class NumberEvaluatorTests
    {
        private readonly NumberEvaluator _numberEvaluator;

        public NumberEvaluatorTests()
        {
            _numberEvaluator = new NumberEvaluator();
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void Resolve_NumberDivisibleByThree_ShouldReturnFizz(int number)
        {
            // arrange

            // act
            var result = _numberEvaluator.Resolve(number);

            // assert
            Assert.Equal("fizz", result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void Resolve_NumberDivisibleByFive_ShouldReturnBuzz(int number)
        {
            // arrange

            // act
            var result = _numberEvaluator.Resolve(number);

            // assert
            Assert.Equal("buzz", result);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        public void Resolve_NumberDivisibleByThreeAndFive_ShouldReturnFizzBuzz(int number)
        {
            // arrange

            // act
            var result = _numberEvaluator.Resolve(number);

            // assert
            Assert.Equal("fizzbuzz", result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(7)]
        public void Resolve_NumberNotDivisibleByThreeOrFive_ShouldReturnNumber(int number)
        {
            // arrange

            // act
            var result = _numberEvaluator.Resolve(number);

            // assert
            Assert.Equal(number.ToString(), result);
        }
    }
}
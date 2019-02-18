using System;
using FizzBuzz.Interfaces;

namespace FizzBuzz
{
    public class NumberEvaluator : INumberEvaluator
    {
        public string Resolve(int number)
        {
            var output = "";

            if (NumberContainsAThree(number))
            {
                return Constants.Lucky;
            }

            if (NumberDivisibleByThree(number))
            {
                output += Constants.Fizz;
            }

            if (NumberDivisibleByFive(number))
            {
                output += Constants.Buzz;
            }

            if (string.IsNullOrEmpty(output))
            {
                return number.ToString();
            }

            return output;
        }

        private bool NumberContainsAThree(int number)
        {
            return number.ToString().Contains("3");
        }

        private static bool NumberDivisibleByThree(int number)
        {
            return number % 3 == 0;
        }

        private static bool NumberDivisibleByFive(int number)
        {
            return number % 5 == 0;
        }
    }
}
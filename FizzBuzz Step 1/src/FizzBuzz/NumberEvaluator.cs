using System;
using FizzBuzz.Interfaces;

namespace FizzBuzz
{
    public class NumberEvaluator : INumberEvaluator
    {
        private const string Fizz = "fizz";
        private const string Buzz = "buzz";

        public string Resolve(int number)
        {
            var output = "";

            if (NumberDivisibleByThree(number))
            {
                output += Fizz;
            }

            if (NumberDivisibleByFive(number))
            {
                output += Buzz;
            }

            if (string.IsNullOrEmpty(output))
            {
                return number.ToString();
            }

            return output;
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
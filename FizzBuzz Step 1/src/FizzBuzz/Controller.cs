using System;
using System.Collections.Generic;
using FizzBuzz.Interfaces;

namespace FizzBuzz
{
    public class Controller : IController
    {
        private readonly INumberEvaluator _numberEvaluator;

        public Controller(INumberEvaluator numberEvaluator)
        {
            _numberEvaluator = numberEvaluator ?? throw new ArgumentException(nameof(numberEvaluator));
        }

        public string Run(int range)
        {
            if (range <= 1)
            {
                throw new ArgumentException("Range should be greater than 1");
            }

            var output = new List<string>();
            for (int i = 1; i <= range; i++)
            {
                output.Add(_numberEvaluator.Resolve(i));
            }
            return string.Join(" ", output);
        }
    }
}

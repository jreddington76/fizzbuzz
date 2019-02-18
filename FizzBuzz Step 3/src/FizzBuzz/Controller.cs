using System;
using System.Collections.Generic;
using FizzBuzz.Interfaces;

namespace FizzBuzz
{
    public class Controller : IController
    {
        private readonly INumberEvaluator _numberEvaluator;
        private readonly ISummary _summary;

        public Controller(INumberEvaluator numberEvaluator, ISummary summary)
        {
            _numberEvaluator = numberEvaluator ?? throw new ArgumentException(nameof(numberEvaluator));
            _summary = summary ?? throw new ArgumentException(nameof(summary));
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
            var results = string.Join(" ", output);

            return $"{results} {_summary.GetResults(output)}";
        }
    }
}

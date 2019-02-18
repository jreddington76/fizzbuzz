using System.Collections.Generic;
using System.Linq;
using FizzBuzz.Interfaces;

namespace FizzBuzz
{
    public class Summary : ISummary
    {
        public string GetResults(IEnumerable<string> sequence)
        {
            var fizz = 0;
            var buzz = 0;
            var fizzbuzz = 0;
            var lucky = 0;
            var i = 0;

            if (sequence != null)
            {
                foreach (var element in sequence)
                {
                    switch (element)
                    {
                        case Constants.Fizz:
                            fizz++;
                            break;
                        case Constants.Buzz:
                            buzz++;
                            break;
                        case Constants.FizzBuzz:
                            fizzbuzz++;
                            break;
                        case Constants.Lucky:
                            lucky++;
                            break;
                        default:
                            i++;
                            break;
                    }
                }
            }

            return $"{Constants.Fizz}: {fizz} {Constants.Buzz}: {buzz} {Constants.FizzBuzz}: {fizzbuzz} {Constants.Lucky}: {lucky} {Constants.Integer}: {i}";
        }
    }
}
using System.Collections.Generic;

namespace FizzBuzz.Interfaces
{
    public interface ISummary
    {
        string GetResults(IEnumerable<string> sequence);
    }
}
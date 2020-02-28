using WebApiCodingChallenge.Middlewares.Errors;
using WebApiCodingChallenge.Services.Wrappers;
using System;

namespace WebApiCodingChallenge.Services.Fibonacci
{
    public class FibonacciService : IFibonacciService
    {
        private const long maxNumber = 92;

        private IMemoryCacheWrapper _memoryCacheWrapper;

        public FibonacciService(IMemoryCacheWrapper memoryCacheWrapper)
        {
            _memoryCacheWrapper = memoryCacheWrapper;
        }

        /// <summary>
        /// Used Binet Formula since it's much faster than an ordinary one and also calculates values for negatives- http://mathworld.wolfram.com/BinetsFibonacciNumberFormula.html
        /// </summary>
        /// <param name="n"> The index (n) of the fibonacci sequence. </param>
        /// <returns> N-th number in the fibonacci sequence. </returns>
        public long GetFibonacci(long n)
        {
            var cacheKey = $"Fibonacci:{n}";
            long result = 0;

            if (IsInputWithinRange(n))
            {
                if (!_memoryCacheWrapper.TryGetValue(cacheKey, out result))
                {
                    result = CalculateBinetFibonacci(n);
                    _memoryCacheWrapper.Set(cacheKey, result);
                }

                return result;
            }
            else
            {
                throw new WrongInputException("Provided wrong input. Only integers from -92 to 92 are accepted.");
            }
        }

        private bool IsInputWithinRange(long n)
        {
            return n >= -maxNumber && n <= maxNumber;
        }

        private long CalculateBinetFibonacci(long n)
        {
            var numeratorLeft = Math.Pow((1.0 + Math.Sqrt(5.0)), n);
            var numeratorRight = Math.Pow((1.0 - Math.Sqrt(5.0)), n);
            var denominator = Math.Pow(2.0, n) * Math.Sqrt(5.0);
            var result = (numeratorLeft - numeratorRight) / denominator;
            var roundResult = Math.Round(result);

            return (long)roundResult;
        }
    }
}

﻿using KnockKnockReadifyChallenge.Middlewares.Errors;
using System;

namespace KnockKnockReadifyChallenge.Services.Fibonacci
{
    public class FibonacciService : IFibonacciService
    {
        private const long MAX_NUMBER = 92;

        /// <summary>
        /// Used Binet Formula since it's much faster than an ordinary one and also calculates values for negatives- http://mathworld.wolfram.com/BinetsFibonacciNumberFormula.html
        /// </summary>
        /// <param name="n"> The index (n) of the fibonacci sequence. </param>
        /// <returns> N-th number in the fibonacci sequence. </returns>
        public long GetFibonacci(long n)
        {
            if (n >= -MAX_NUMBER && n <= MAX_NUMBER)
            {
                return CalculateBinetFibonacci(n);
            }
            else
            {
                throw new WrongInputException("Provided wrong input. Only integers from -92 to 92 are accepted.");
            }
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

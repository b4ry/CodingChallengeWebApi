using KnockKnockReadifyChallenge.Services.Fibonacci;
using Xunit;

namespace KnockKnockReadifyChallenge.Tests
{
    public class FibonacciServiceTest
    {
        [Fact]
        public void GetFibonacciMethodMustReturnProperValueForPositiveInteger()
        {
            var fibonacciService = new FibonacciService();

            var result = fibonacciService.GetFibonacci(10);

            Assert.Equal(55, result);
        }
    }
}

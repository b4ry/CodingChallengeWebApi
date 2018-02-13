using KnockKnockReadifyChallenge.Middlewares.Errors;
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

        [Fact]
        public void GetFibonacciMethodMustReturnZeroForInputEqualsZero()
        {
            var fibonacciService = new FibonacciService();

            var result = fibonacciService.GetFibonacci(0);

            Assert.Equal(0, result);
        }

        [Fact]
        public void GetFibonacciMethodMustReturnProperValueForNegativeInteger()
        {
            var fibonacciService = new FibonacciService();

            var result = fibonacciService.GetFibonacci(-10);

            Assert.Equal(-55, result);
        }

        [Fact]
        public void GetFibonacciMethodMustThrowWrongInputExceptionWhenInputIsBiggerThan92()
        {
            var fibonacciService = new FibonacciService();

            Assert.Throws<WrongInputException>(() => fibonacciService.GetFibonacci(93));
        }

        [Fact]
        public void GetFibonacciMethodMustThrowWrongInputExceptionWhenInputIsSmallerThanMinus92()
        {
            var fibonacciService = new FibonacciService();

            Assert.Throws<WrongInputException>(() => fibonacciService.GetFibonacci(-93));
        }
    }
}

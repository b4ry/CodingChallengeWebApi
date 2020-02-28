using WebApiCodingChallenge.Middlewares.Errors;
using WebApiCodingChallenge.Services.Fibonacci;
using WebApiCodingChallenge.Services.Wrappers;
using Moq;
using Xunit;

namespace WebApiCodingChallenge.Tests.Services
{
    public class FibonacciServiceTest
    {
        [Fact]
        public void GetFibonacciMethodMustReturnProperValueForPositiveInteger()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var fibonacciService = new FibonacciService(mockedMemoryCacheWrapper.Object);

            var result = fibonacciService.GetFibonacci(10);

            Assert.Equal(55, result);
        }

        [Fact]
        public void GetFibonacciMethodMustReturnZeroForInputEqualsZero()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var fibonacciService = new FibonacciService(mockedMemoryCacheWrapper.Object);

            var result = fibonacciService.GetFibonacci(0);

            Assert.Equal(0, result);
        }

        [Fact]
        public void GetFibonacciMethodMustReturnProperValueForNegativeInteger()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var fibonacciService = new FibonacciService(mockedMemoryCacheWrapper.Object);

            var result = fibonacciService.GetFibonacci(-10);

            Assert.Equal(-55, result);
        }

        [Fact]
        public void GetFibonacciMethodMustThrowWrongInputExceptionWhenInputIsBiggerThan92()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var fibonacciService = new FibonacciService(mockedMemoryCacheWrapper.Object);

            Assert.Throws<WrongInputException>(() => fibonacciService.GetFibonacci(93));
        }

        [Fact]
        public void GetFibonacciMethodMustThrowWrongInputExceptionWhenInputIsSmallerThanMinus92()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var fibonacciService = new FibonacciService(mockedMemoryCacheWrapper.Object);

            Assert.Throws<WrongInputException>(() => fibonacciService.GetFibonacci(-93));
        }
    }
}

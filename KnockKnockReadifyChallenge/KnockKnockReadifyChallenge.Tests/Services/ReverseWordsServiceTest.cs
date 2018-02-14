using KnockKnockReadifyChallenge.Services.ReverseWords;
using KnockKnockReadifyChallenge.Services.Wrappers;
using Moq;
using Xunit;

namespace KnockKnockReadifyChallenge.Tests.Services
{
    public class ReverseWordsServiceTest
    {
        [Fact]
        public void ReverseWordsMethodMustReturnEmptyStringWhenInputIsEmpty()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var reverseWordsService = new ReverseWordsService(mockedMemoryCacheWrapper.Object);

            var result = reverseWordsService.ReverseWords(string.Empty);

            Assert.Equal(string.Empty, result);
        }
    }
}

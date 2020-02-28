using WebApiCodingChallenge.Services.ReverseWords;
using WebApiCodingChallenge.Services.Wrappers;
using Moq;
using Xunit;

namespace WebApiCodingChallenge.Tests.Services
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

        [Fact]
        public void ReverseWordsMethodMustTreatNullStringAsEmpty()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var reverseWordsService = new ReverseWordsService(mockedMemoryCacheWrapper.Object);

            var result = reverseWordsService.ReverseWords(null);

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void ReverseWordsMethodMustReverseInputWhenSingleWordWithoutWhiteSpacesIsProvided()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var reverseWordsService = new ReverseWordsService(mockedMemoryCacheWrapper.Object);

            var result = reverseWordsService.ReverseWords("test");

            Assert.Equal("tset", result);
        }

        [Fact]
        public void ReverseWordsMethodMustReverseVeryLongInput()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var reverseWordsService = new ReverseWordsService(mockedMemoryCacheWrapper.Object);

            var result = reverseWordsService.ReverseWords("imaverylongwordsoyoushouldbecarefulreversingme!");

            Assert.Equal("!emgnisreverluferacebdluohsuoyosdrowgnolyrevami", result);
        }

        [Fact]
        public void ReverseWordsMethodMustTreatWordsSeparatedByAnyCharDelimetersAsSingleWord()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var reverseWordsService = new ReverseWordsService(mockedMemoryCacheWrapper.Object);

            var result = reverseWordsService.ReverseWords("test,rest.west;vest");

            Assert.Equal("tsev;tsew.tser,tset", result);
        }

        [Fact]
        public void ReverseWordsMethodsMustReverseEscapeSequences()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var reverseWordsService = new ReverseWordsService(mockedMemoryCacheWrapper.Object);

            var result = reverseWordsService.ReverseWords("\\n\\t\\r");

            Assert.Equal("r\\t\\n\\", result);
        }

        [Fact]
        public void ReverseWordsMethodsMustReverseWordsContainingSpecialCharacters()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var reverseWordsService = new ReverseWordsService(mockedMemoryCacheWrapper.Object);

            var result = reverseWordsService.ReverseWords("P()|-3|\\/|@000|\\|$");

            Assert.Equal("$|\\|000@|/\\|3-|)(P", result);
        }

        [Fact]
        public void ReverseWordsMethodMustReturnIdenticalWhenInputIsSingleWordPalindrome()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var reverseWordsService = new ReverseWordsService(mockedMemoryCacheWrapper.Object);

            var result = reverseWordsService.ReverseWords("saas");

            Assert.Equal("saas", result);
        }

        [Fact]
        public void ReverseWordsMethodMustTreatWordsSeparatedByWhiteSpaceAsSeparatedWords()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var reverseWordsService = new ReverseWordsService(mockedMemoryCacheWrapper.Object);

            var result = reverseWordsService.ReverseWords("test rest");

            Assert.Equal("tset tser", result);
        }

        [Fact]
        public void ReverseWordsMethodMustNotRemoveInitialSpaces()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var reverseWordsService = new ReverseWordsService(mockedMemoryCacheWrapper.Object);

            var result = reverseWordsService.ReverseWords(" test rest");

            Assert.Equal(" tset tser", result);
        }

        [Fact]
        public void ReverseWordsMethodMustNotRemoveAnySpaces()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var reverseWordsService = new ReverseWordsService(mockedMemoryCacheWrapper.Object);

            var result = reverseWordsService.ReverseWords("  test     rest            VEST      ");

            Assert.Equal("  tset     tser            TSEV      ", result);
        }
    }
}

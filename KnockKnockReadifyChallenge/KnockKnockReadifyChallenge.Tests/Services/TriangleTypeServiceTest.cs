using KnockKnockReadifyChallenge.Services.TriangleType;
using KnockKnockReadifyChallenge.Services.Wrappers;
using Moq;
using Xunit;

namespace KnockKnockReadifyChallenge.Tests.Services
{
    public class TriangleTypeServiceTest
    {
        [Fact]
        public void DetermineTriangleTypeMethodMustReturnErrorTypeForSidesLengthOfZero()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(0, 0, 0);

            Assert.Equal("Error", triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustNotReturnErrorTypeForValidTriangle()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(7, 10, 5);

            Assert.NotEqual("Error", triangleType);
        }
    }
}

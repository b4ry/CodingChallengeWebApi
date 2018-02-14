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

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnErrorTypeIfSidesAAndBAreNotBiggerThanC()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(5, 3, 8);

            Assert.Equal("Error", triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnErrorTypeIfSidesAAndCAreNotBiggerThanB()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(2, 3, 1);

            Assert.Equal("Error", triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnErrorTypeIfSidesBAndCAreNotBiggerThanA()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(10, 2, 3);

            Assert.Equal("Error", triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnErrorTypeForNegativeSideA()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(-1, 5, 3);

            Assert.Equal("Error", triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnErrorTypeForNegativeSideB()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(5, -1, 3);

            Assert.Equal("Error", triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnErrorTypeForNegativeSideC()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(3, 5, -1);

            Assert.Equal("Error", triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnErrorTypeForAllSidesNegative()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(-1, -1, -1);

            Assert.Equal("Error", triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustNotReturnErrorTypeForSidesLengthOfMaxInteger()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(2147483647, 2147483647, 2147483647);

            Assert.NotEqual("Error", triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnEquilateralTypeForSidesLengthOfMaxInteger()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(2147483647, 2147483647, 2147483647);

            Assert.Equal("Equilateral", triangleType);
        }
    }
}

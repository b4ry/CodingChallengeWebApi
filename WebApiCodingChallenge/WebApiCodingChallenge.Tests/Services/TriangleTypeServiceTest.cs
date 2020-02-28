using WebApiCodingChallenge.Services.TriangleType;
using WebApiCodingChallenge.Services.Wrappers;
using Moq;
using Xunit;

namespace WebApiCodingChallenge.Tests.Services
{
    public class TriangleTypeServiceTest
    {
        [Fact]
        public void DetermineTriangleTypeMethodMustReturnErrorTypeForSidesLengthOfZero()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(0, 0, 0);

            Assert.Equal(TriangleTypeEnum.Error, triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustNotReturnErrorTypeForValidTriangle()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(7, 10, 5);

            Assert.NotEqual(TriangleTypeEnum.Error, triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnErrorTypeIfSidesAAndBAreNotBiggerThanC()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(5, 3, 8);

            Assert.Equal(TriangleTypeEnum.Error, triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnErrorTypeIfSidesAAndCAreNotBiggerThanB()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(2, 3, 1);

            Assert.Equal(TriangleTypeEnum.Error, triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnErrorTypeIfSidesBAndCAreNotBiggerThanA()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(10, 2, 3);

            Assert.Equal(TriangleTypeEnum.Error, triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnErrorTypeForNegativeSideA()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(-1, 5, 3);

            Assert.Equal(TriangleTypeEnum.Error, triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnErrorTypeForNegativeSideB()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(5, -1, 3);

            Assert.Equal(TriangleTypeEnum.Error, triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnErrorTypeForNegativeSideC()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(3, 5, -1);

            Assert.Equal(TriangleTypeEnum.Error, triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnErrorTypeForAllSidesNegative()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(-1, -1, -1);

            Assert.Equal(TriangleTypeEnum.Error, triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustNotReturnErrorTypeForSidesLengthOfMaxInteger()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(2147483647, 2147483647, 2147483647);

            Assert.NotEqual(TriangleTypeEnum.Error, triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnEquilateralTypeForAllSidesEqual()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(2147483647, 2147483647, 2147483647);

            Assert.Equal(TriangleTypeEnum.Equilateral, triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnIsoscelesTypeForAnyTwoSidesEqualAndOneDifferent()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(2147483647, 2147483646, 2147483647);

            Assert.Equal(TriangleTypeEnum.Isosceles, triangleType);
        }

        [Fact]
        public void DetermineTriangleTypeMethodMustReturnScaleneTypeForAllSidesDifferent()
        {
            var mockedMemoryCacheWrapper = new Mock<IMemoryCacheWrapper>();
            var triangleTypeService = new TriangleTypeService(mockedMemoryCacheWrapper.Object);

            var triangleType = triangleTypeService.DetermineTriangleType(2147483647, 2147483646, 2147483645);

            Assert.Equal(TriangleTypeEnum.Scalene, triangleType);
        }
    }
}

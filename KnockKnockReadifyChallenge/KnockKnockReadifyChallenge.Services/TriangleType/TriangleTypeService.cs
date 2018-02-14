using KnockKnockReadifyChallenge.Services.Wrappers;

namespace KnockKnockReadifyChallenge.Services.TriangleType
{
    public class TriangleTypeService : ITriangleTypeService
    {
        private IMemoryCacheWrapper _memoryCacheWrapper;

        public TriangleTypeService(IMemoryCacheWrapper memoryCacheWrapper)
        {
            _memoryCacheWrapper = memoryCacheWrapper;
        }

        public TriangleTypeEnum DetermineTriangleType(int sideA, int sideB, int sideC)
        {
            bool doesTriangleExist = DoesTriangleExist(sideA, sideB, sideC);

            if(!doesTriangleExist)
            {
                return TriangleTypeEnum.Error;
            }

            var cacheKey = $"TriangleType:{sideA};{sideB};{sideC}";
            TriangleTypeEnum result;

            if (!_memoryCacheWrapper.TryGetValue(cacheKey, out result))
            {
                result = CalculateTriangleType(sideA, sideB, sideC);
                _memoryCacheWrapper.Set(cacheKey, result);
            }

            return result;
        }

        private bool DoesTriangleExist(int sideA, int sideB, int sideC)
        {
            long sideALong = sideA;
            long sideBLong = sideB;
            long sideCLong = sideC;

            if (IsAnySideNegative(sideA, sideB, sideC))
            {
                return false;
            }

            return CanCloseTriangle(sideALong, sideBLong, sideCLong);
        }

        private bool IsAnySideNegative(int sideA, int sideB, int sideC)
        {
            return sideA < 0 || sideB < 0 || sideC < 0;
        }

        private static bool CanCloseTriangle(long sideA, long sideB, long sideC)
        {
            bool canCloseTriangle = true;

            canCloseTriangle = canCloseTriangle && IsSumOfTwoSidesBiggerThanThird(sideA, sideB, sideC);
            canCloseTriangle = canCloseTriangle && IsSumOfTwoSidesBiggerThanThird(sideA, sideC, sideB);
            canCloseTriangle = canCloseTriangle && IsSumOfTwoSidesBiggerThanThird(sideB, sideC, sideA);

            return canCloseTriangle;
        }

        private static bool IsSumOfTwoSidesBiggerThanThird(long sideA, long sideB, long sideC)
        {
            return (sideA + sideB) > sideC;
        }

        private TriangleTypeEnum CalculateTriangleType(int sideA, int sideB, int sideC)
        {
            if (AreAllOfTriangleSidesEqual(sideA, sideB, sideC))
            {
                return TriangleTypeEnum.Equilateral;
            }

            return TriangleTypeEnum.Other;
        }

        private static bool AreAllOfTriangleSidesEqual(int sideA, int sideB, int sideC)
        {
            return sideA == sideB && sideA == sideC && sideB == sideC;
        }
    }
}

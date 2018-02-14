using System;
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

        public string DetermineTriangleType(int a, int b, int c)
        {
            long aLong = a;
            long bLong = b;
            long cLong = c;

            bool doesTriangleExist = DoesTriangleExist(aLong, bLong, cLong);

            if(!doesTriangleExist)
            {
                return "Error";
            }

            return "SomeTriangle";
        }

        private bool DoesTriangleExist(long a, long b, long c)
        {
            if (a < 0 || b < 0 || c < 0)
            {
                return false;
            }

            if (!((a + b) > c))
            {
                return false;
            }

            if (!((a + c) > b))
            {
                return false;
            }

            if (!((b + c) > a))
            {
                return false;
            }

            return true;
        }
    }
}

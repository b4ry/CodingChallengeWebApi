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
            bool doesTriangleExist = DoesTriangleExist(a, b, c);

            if(!doesTriangleExist)
            {
                return "Error";
            }

            return "SomeTriangle";
        }

        private bool DoesTriangleExist(int a, int b, int c)
        {
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

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
            return "Error";
        }
    }
}

namespace WebApiCodingChallenge.Services.TriangleType
{
    public interface ITriangleTypeService
    {
        TriangleTypeEnum DetermineTriangleType(int sideA, int sideB, int sideC);
    }
}
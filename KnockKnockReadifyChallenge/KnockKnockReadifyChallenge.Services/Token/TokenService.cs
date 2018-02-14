namespace KnockKnockReadifyChallenge.Services.Token
{
    public class TokenService : ITokenService
    {
        private const string token = "00000000-0000-0000-0000-000000000000";

        public string GetToken()
        {
            return token;
        }
    }
}

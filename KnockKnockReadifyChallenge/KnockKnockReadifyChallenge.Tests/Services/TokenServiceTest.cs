using KnockKnockReadifyChallenge.Services.Token;
using Xunit;

namespace KnockKnockReadifyChallenge.Tests.Services
{
    public class TokenServiceTest
    {
        [Fact]
        public void GetTokenMethodMustReturnToken()
        {
            var tokenService = new TokenService();

            var token = tokenService.GetToken();

            Assert.Equal("00000000-0000-0000-0000-000000000000", token);
        }
    }
}

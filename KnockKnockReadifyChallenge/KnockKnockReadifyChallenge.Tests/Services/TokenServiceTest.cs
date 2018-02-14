using KnockKnockReadifyChallenge.Services.Token;
using System.Text.RegularExpressions;
using Xunit;

namespace KnockKnockReadifyChallenge.Tests.Services
{
    public class TokenServiceTest
    {
        [Fact]
        public void GetTokenMethodMustReturnValidToken()
        {
            Regex regex = new Regex(@"\w{8}[-]{1}\w{4}[-]{1}\w{4}[-]{1}\w{4}[-]{1}\w{12}");
            var tokenService = new TokenService();

            var token = tokenService.GetToken();
            var match = regex.Match(token);

            Assert.True(match.Success, "Token has invalid format");
        }
    }
}

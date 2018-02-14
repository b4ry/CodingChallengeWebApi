using KnockKnockReadifyChallenge.Services.Token;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnockReadifyChallenge.Api.Controllers
{
    /// <summary>
    /// Controller exposing an endpoint to retrieve token.
    /// </summary>
    [Produces("application/json", "text/json")]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        /// <summary>
        /// Your token.
        /// </summary>
        /// <remarks> Your token. </remarks>
        /// <returns> Token. </returns>
        [ProducesResponseType(200, Type = typeof(string))]
        [HttpGet]
        public string Get()
        {
            return _tokenService.GetToken();
        }
    }
}

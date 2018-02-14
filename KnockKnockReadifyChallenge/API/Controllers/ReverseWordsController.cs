using KnockKnockReadifyChallenge.Services.ReverseWords;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KnockKnockReadifyChallenge.Api.Controllers
{
    /// <summary>
    /// Controller exposing an endpoint to reverse provided words.
    /// </summary>
    [Produces("application/json", "text/json")]
    [Route("api/[controller]")]
    public class ReverseWordsController : Controller
    {
        private IReverseWordsService _reverseWordsService;

        public ReverseWordsController(IReverseWordsService reverseWordsService)
        {
            _reverseWordsService = reverseWordsService;
        }
        /// <summary>
        /// Reverses the letters of each word in a sentence.
        /// </summary>
        /// <remarks> Reverses the letters of each word in a sentence. </remarks>
        /// <param name="sentence"> A sentence </param>
        /// <returns> Reversed letters of each word in provided sentence </returns>
        [ProducesResponseType(200, Type = typeof(string))]
        [HttpGet]
        public string Get([Required]string sentence)
        {
            return _reverseWordsService.ReverseWords(sentence);
        }
    }
}

using KnockKnockReadifyChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KnockKnockReadifyChallenge.Api.Controllers
{
    /// <summary>
    /// Controller exposing an endpoint to retrieve the n-th number in the fibonacci sequence.
    /// </summary>
    [Produces("application/json", "text/json")]
    [Route("api/[controller]")]
    public class FibonacciController : Controller
    {
        private IFibonacciService _fibonacciService;

        public FibonacciController(IFibonacciService fibonacciService)
        {
            _fibonacciService = fibonacciService;
        }

        /// <summary>
        /// Returns the nth fibonacci number.
        /// </summary>
        /// <remarks> Returns the n-th number in the fibonacci sequence. </remarks>
        /// <param name="n"> The index (n) of the fibonacci sequence. </param>
        /// <returns> N-th number in the fibonacci sequence. </returns>
        [ProducesResponseType(200, Type = typeof(long))]
        [ProducesResponseType(400)]
        [HttpGet]
        public long Get([Required]long n)
        {
            return _fibonacciService.GetFibonacci(n);
        }
    }
}

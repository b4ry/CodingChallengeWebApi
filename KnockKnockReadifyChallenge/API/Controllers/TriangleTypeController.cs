using KnockKnockReadifyChallenge.Services.TriangleType;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KnockKnockReadifyChallenge.Api.Controllers
{
    /// <summary>
    /// Controller exposing an endpoint to determine the type of a triangle.
    /// </summary>
    [Produces("application/json", "text/json")]
    [Route("api/[controller]")]
    public class TriangleTypeController : Controller
    {
        private ITriangleTypeService _triangleTypeService;

        public TriangleTypeController(ITriangleTypeService triangleTypeService)
        {
            _triangleTypeService = triangleTypeService;
        }
        /// <summary>
        /// Returns the type of triangle given the lengths of its sides.
        /// </summary>
        /// <remarks> Returns the type of triangle given the lengths of its sides. </remarks>
        /// <param name="a"> The length of side a. </param>
        /// <param name="b"> The length of side b. </param>
        /// <param name="c"> The length of side c. </param>
        /// <returns> N-th number in the fibonacci sequence. </returns>
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        [HttpGet]
        public string Get([Required]int a, [Required]int b, [Required]int c)
        {
            return _triangleTypeService.DetermineTriangleType(a, b, c);
        }
    }
}

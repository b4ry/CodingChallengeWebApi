using KnockKnockReadifyChallenge.Middlewares.Errors;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KnockKnockReadifyChallenge.Middlewares.Filters
{
    public class ModelValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                throw new WrongInputException("Invalid request.");
            }
        }
    }
}

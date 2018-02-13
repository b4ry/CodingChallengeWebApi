using Microsoft.AspNetCore.Mvc.Filters;
using System;

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
                throw new Exception("Invalid request.");
            }
        }
    }
}

using KnockKnockReadifyChallenge.Middlewares.Errors;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

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
                var errorMessage = "Provided wrong inputs. Invalid inputs - ";

                var errors = context.ModelState
                    .Where(p => p.Value.ValidationState == ModelValidationState.Invalid)
                    .Select(invalidProp => new { PropertyName = invalidProp.Key, InvalidValue = invalidProp.Value.RawValue })
                    .ToArray();

                foreach (var error in errors)
                {
                    errorMessage += $"{error.PropertyName} : {error.InvalidValue}; ";
                }

                throw new WrongInputException(errorMessage);
            }
        }
    }
}

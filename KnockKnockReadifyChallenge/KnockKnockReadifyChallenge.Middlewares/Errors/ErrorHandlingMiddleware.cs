using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace KnockKnockReadifyChallenge.Middlewares.Errors
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            if (e is WrongInputException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }

            context.Response.ContentType = "application/json";
            var response = JsonConvert.SerializeObject(new { errorMessage = e.Message });

            await context.Response.WriteAsync(response);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace StudentApp.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Log the exception
            Debug.WriteLine("Exception occurred:" + context.Exception.Message);

            // Set the result to a custom error response
            context.Result = new ObjectResult(new
            {
                Error = "An unexpected error occurred."
            })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
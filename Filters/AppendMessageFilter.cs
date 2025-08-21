using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentApp.Filters
{
    public class AppendMessageFilter : IActionFilter //This filter appends message to the response
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Logic before the action executes
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Logic after the action executes
            if (context.Result is ObjectResult objectResult)
            {
                // Append a message to the response
                objectResult.Value = $"{objectResult.Value} - This is an appended message.";
                Console.WriteLine("Response modified by AppendMessageFilter.");
            }
        }
    }
}
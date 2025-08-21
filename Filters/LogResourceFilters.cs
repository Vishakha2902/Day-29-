//Here we will be creating a class i.e LogResourceFilter for implementing custom filter
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace StudentApp.Filters
{
    public class LogResourceFilter : IResourceFilter //Interface with resource filter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // Log the incoming request
            Console.WriteLine("Incoming request: " + context.HttpContext.Request.Path);
            //Debug.WriteLine will write log to the output window
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // Log the outgoing response
            Console.WriteLine("Outgoing response: " + context.HttpContext.Response.StatusCode);
        }
    }
}
//Here , I will implement action filters for input validation
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace StudentApp.Filters
{
    public class ValidateStudentFilter : IActionFilter
    {
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Validate the incoming student data
            Console.WriteLine("Validating student data:" + context.ActionDescriptor.DisplayName);

            // Add your validation logic here
            // Checking input from user 
            if (context.ActionArguments.ContainsKey("student"))
            {
                var name = context.ActionArguments["name"] as string;
                if (string.IsNullOrEmpty(name))
                {
                    context.ModelState.AddModelError("name", "Name is required.");
                    Console.WriteLine("Validation failed: Name is required.");
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Logic after the action executes
            Debug.WriteLine("Action executed:" + context.ActionDescriptor.DisplayName);

            // Check if the model state is valid
            if (context.ModelState.IsValid)
            {
                Debug.WriteLine("Validation succeeded.");
            }
            else
            {
                Debug.WriteLine("Validation failed: " + context.ModelState.ToString());
            }
        }
    }
}
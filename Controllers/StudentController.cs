using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Filters;

namespace Controllers
{
    public class StudentController : ControllerBase
    {
        // Your action methods go here
        [HttpGet]
        [Route("Student/details")]
        [Authorize] //Authorization filter
        public IActionResult Details()
        {
            // Logic to retrieve students
            return Ok("Student details can only be seen by authorized users");
        }

        //This attribute will trigger the validation filter that we have created for
        //user input validating the input during the time action method is running
        [ServiceFilter(typeof(StudentApp.Filters.ValidateStudentFilter))]
        [HttpGet("Student/add/{name}")]
        [ServiceFilter(typeof(StudentApp.Filters.LogResourceFilter))]
        public IActionResult Add(string name)
        {
            // Logic to add a student
            return Ok($"Student {name} added successfully.");
        }

        [HttpGet("Student/error-test")] //For testing error handling
        public IActionResult ErrorTest()
        {
            throw new Exception("This is a test exception");
            //This will trigger the custom exception filter instead of crashing the application
        }

    }
}
using iBosAssesmentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using static iBosAssesmentAPI.Models.IBosDbContext;


namespace iBosAssesmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet]
        [Route("API02")]
        public IActionResult get3rdMaxSalary()
        {
            using (var context = new IBosDbContext())

            {
                var employee = context.TblEmployees
                    .OrderByDescending(e => e.EmployeeSalary)
                    .Skip(2) // Skip the top 2 employees (1st and 2nd highest salaries)
                    .Take(1) // Take 1 employee (3rd highest salary)
                    .FirstOrDefault();
                return (employee != null)? Ok(employee): NotFound("No employee found with the 3rd highest salary.");
            }
        }
    }

}

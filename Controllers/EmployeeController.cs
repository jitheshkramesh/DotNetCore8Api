using DotNetCore8Api.Data;
using DotNetCore8Api.Models;
using DotNetCore8Api.Services;
using DotNetCore8Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore8Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository dbContext)
        {
            _employeeRepository = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _employeeRepository.GetAll();
                if (result.Any())
                {
                    return Ok(result);
                    
                }
                return NotFound();
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        //[HttpGet]
        //public async Task<List<Employee>> GetEmployees()
        //{
        //    return (List<Employee>)await _employeeRepository.GetAll(); 
        //}
    }
}

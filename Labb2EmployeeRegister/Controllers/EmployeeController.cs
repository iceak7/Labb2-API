using Labb2EmployeeRegister.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labb2EmployeeRegister.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll().ToList();

            return Ok(employees);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetSingleEmployee([FromRoute]int id)
        {
            var employee = _employeeRepository.GetSingle(id);

            if(employee == null)
            {
                return NotFound("Not found");
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddAEmployee([FromBody]Employee employee)
        {
            var addedEmployee = _employeeRepository.AddEmployee(employee);

            return CreatedAtAction(nameof(GetSingleEmployee), new { id = addedEmployee.EmployeeId }, addedEmployee);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEmployee([FromRoute]int id)
        {
            var deletedEmployee = _employeeRepository.DeleteEmployee(id);

            if(deletedEmployee == null)
            {
                return NotFound("Could not find and delete the employee");
            }

            return Ok(deletedEmployee);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateEmployee([FromRoute]int id, Employee employee)
        {
            employee.EmployeeId = id;

            var updatedEmployee = _employeeRepository.UpdateEmployee(employee);

            if(updatedEmployee == null)
            {
                return BadRequest("Bad request. Try again.");
            }

            return Ok(updatedEmployee);
        }



    }
}

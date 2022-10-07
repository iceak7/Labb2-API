using Labb2EmployeeRegister.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labb2EmployeeRegister.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepository _departmentsRepository;
        public DepartmentsController(IDepartmentRepository departmentsRepository)
        {
            _departmentsRepository = departmentsRepository;
        }
        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var departments = _departmentsRepository.GetAll();
            return Ok(departments);
        }
    }
}

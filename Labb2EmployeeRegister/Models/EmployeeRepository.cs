using Microsoft.EntityFrameworkCore;

namespace Labb2EmployeeRegister.Models
{
    public class EmployeeRepository : IEmployeeRepository { 
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
 
        public Employee AddEmployee(Employee employee)
        {
            var addedEmployee = _appDbContext.Employees.Add(employee);
            _appDbContext.SaveChanges();
            return addedEmployee.Entity;
        }

        public Employee DeleteEmployee(int id)
        {
            var employeeToDelete = GetSingle(id);

            if(employeeToDelete != null)
            {
                _appDbContext.Employees.Remove(employeeToDelete);
                _appDbContext.SaveChanges();
                return employeeToDelete;
            }
            return null;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _appDbContext.Employees.Include(e=>e.Department);
        }

        public Employee GetSingle(int id)
        {
            return _appDbContext.Employees.Include(e=>e.Department).FirstOrDefault(e=>e.EmployeeId == id);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            if (_appDbContext.Employees.AsNoTracking().FirstOrDefault(e=>e.EmployeeId==employee.EmployeeId)!=null)
            {
                var updatedEmployee = _appDbContext.Employees.Update(employee);
                _appDbContext.SaveChanges();
                return updatedEmployee.Entity;

            }

            return null;

        }
    }
}

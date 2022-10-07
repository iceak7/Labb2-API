namespace Labb2EmployeeRegister.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetSingle(int id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        Employee DeleteEmployee(int id);
    }
}

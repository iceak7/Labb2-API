namespace Labb2EmployeeRegister.Models
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
    }
}

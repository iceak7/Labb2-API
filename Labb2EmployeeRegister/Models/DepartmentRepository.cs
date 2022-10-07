namespace Labb2EmployeeRegister.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;
        public DepartmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Department> GetAll()
        {
            return _appDbContext.Departments;
        }
    }
}

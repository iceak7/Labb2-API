using System.Text.Json.Serialization;

namespace Labb2EmployeeRegister.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        [JsonIgnore]
        public ICollection<Employee>? Employees { get; set; }


    }
}

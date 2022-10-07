using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Labb2EmployeeRegister.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
        public int DepartmentId { get; set; }
        [JsonIgnore]
        public Department? Department { get; set; }

    }
}

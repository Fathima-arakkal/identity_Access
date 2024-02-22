namespace IdClaimsPractice3.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeNumber { get; set; }
        public Gender Gender { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}

namespace DotNetCore8Api.Models
{
    public class Employee : BaseModelEntity
    { 
        public string Name { get; set; }
        public string? Gender { get; set; }
        public Nullable<int> Salary { get; set; }
        public string? Dept { get; set; }
    }
}

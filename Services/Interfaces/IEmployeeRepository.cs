using DotNetCore8Api.Models;

namespace DotNetCore8Api.Services.Interfaces
{
    public interface IEmployeeRepository
    { 
       Task<IEnumerable<Employee>> GetAll();
        Employee GetById(int EmployeeID);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(int EmployeeID);
        void Save();
    }
}

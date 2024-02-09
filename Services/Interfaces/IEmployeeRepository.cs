using DotNetCore8Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore8Api.Services.Interfaces
{
    public interface IEmployeeRepository
    { 
       Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int EmployeeID);
        Task<Employee> Insert(Employee employee);
        Task<Employee> Update(Employee employee);
        Task<bool> Delete(int EmployeeID);
        void Save();
    }
}

using EmployeeManager.Models;
using System.Collections.Generic;

namespace EmployeeManager.DAL
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeDetail(int id);
        IList<Employee> SearchEmployeesWithFirstName(string name);
        IList<Employee> GetAllEmployees();
        bool AddNewEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);
    }
}

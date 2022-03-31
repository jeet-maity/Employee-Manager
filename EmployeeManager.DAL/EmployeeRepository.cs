using DataClient;
using EmployeeManager.Models;
using System.Collections.Generic;

namespace EmployeeManager.DAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IUsersDataClient dataClient;

        public EmployeeRepository(IUsersDataClient dataClient)
        {
            this.dataClient = dataClient;
        }

        public bool AddNewEmployee(Employee employee)
        {
            return dataClient.PostNewUser(ObjectRelationalMapper.MapEmployeeToUser(employee));
        }

        public bool DeleteEmployee(int id)
        {
            return dataClient.DeleteUser(id);
        }

        public IList<Employee> GetAllEmployees()
        {
            return ObjectRelationalMapper.MapUsersToEmployees(dataClient.GetAllUsers());
        }

        public Employee GetEmployeeDetail(int id)
        {
            return ObjectRelationalMapper.MapUserToEmployee(dataClient.GetByID(id));
        }

        public IList<Employee> SearchEmployeesWithFirstName(string firstName)
        {
            return ObjectRelationalMapper.MapUsersToEmployees(dataClient.SearchUsersByName(firstName));
        }

        public bool UpdateEmployee(Employee employee)
        {
            return dataClient.PatchExistingUser(ObjectRelationalMapper.MapEmployeeToUser(employee));
        }
    }
}

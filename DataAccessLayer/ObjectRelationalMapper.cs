using DataClient;
using Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    static class ObjectRelationalMapper
    {
        public static List<Employee> MapUsersToEmployees(List<UserDTO> users)
        {
            List<Employee> employees = new List<Employee>();
            foreach (var user in users)
            {
                employees.Add(MapUserToEmployee(user));
            }
            return employees;
        }

        public static UserDTO MapEmployeeToUser(Employee employee)
        {
            return new UserDTO
            {
                id = employee.Id,
                name = employee.Name,
                email = employee.Email,
                gender = employee.Gender,
                status = employee.Status,
                created_at = DateTime.UtcNow,
                updated_at = DateTime.UtcNow
            };
        }

        public static Employee MapUserToEmployee(UserDTO user)
        {
            return new Employee
            {
                Id = user.id,
                Name = user.name,
                Email = user.email,
                Gender = user.gender,
                Status = user.status
            };
        }
    }
}

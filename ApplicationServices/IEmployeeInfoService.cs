﻿using Models;
using System.Collections.Generic;

namespace ApplicationServices
{
    public interface IEmployeeInfoService
    {
        Employee GetEmployeeDetail(int id);
        IList<Employee> SearchEmployeesWithFirstName(string firstName);
        IList<Employee> GetAllEmployees();
        bool AddNewEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);
        string ExportDetails(IList<Employee> employees, string listName);
    }
}

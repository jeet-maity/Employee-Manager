using EmployeeManager.DAL;
using EmployeeManager.Infra;
using EmployeeManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EmployeeManager.Services
{
    public class EmployeeInfoService : IEmployeeInfoService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IFileSystemService fileSystemService;

        public EmployeeInfoService(IEmployeeRepository employeeRepository, IFileSystemService fileSystemService)
        {
            this.employeeRepository = employeeRepository;
            this.fileSystemService = fileSystemService;
        }

        public IList<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAllEmployees();
        }

        public Employee GetEmployeeDetail(int id)
        {
            return employeeRepository.GetEmployeeDetail(id);
        }

        public bool AddNewEmployee(Employee employee)
        {
            return employeeRepository.AddNewEmployee(employee);
        }

        public bool DeleteEmployee(int id)
        {
            return employeeRepository.DeleteEmployee(id);
        }

        public string ExportDetails(IList<Employee> employees, string listName)
        {
            return fileSystemService.Save(employees, listName);
        }

        public IList<Employee> SearchEmployeesWithFirstName(string firstName)
        {
            return employeeRepository.SearchEmployeesWithFirstName(firstName);
        }

        public bool UpdateEmployee(Employee employee)
        {
            return employeeRepository.UpdateEmployee(employee);
        }
    }
}

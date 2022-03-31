using EmployeeManager.Models;
using EmployeeManager.Services;
using EmployeeManager.Utility;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EmployeeManager.ViewModels
{
    public class SearchResultsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private readonly IEmployeeInfoService employeeInfoService;
        private readonly IDialogService dialogService;

        public SearchResultsViewModel(IEmployeeInfoService employeeInfoService, IDialogService dialogService)
        {
            this.employeeInfoService = employeeInfoService;
            this.dialogService = dialogService;
            SearchCommand = new CustomCommand(SearchEmployeeName, CanSearchEmployeeName);
            ExportCommand = new CustomCommand(ExportEmployeeList, CanExportEmployeeList);
        }

        public ICommand SearchCommand { get; set; }
        public ICommand ExportCommand { get; set; }

        private bool CanSearchEmployeeName(object obj)
        {
            return true;
        }
        private void SearchEmployeeName(object obj)
        {
            Employees = employeeInfoService.SearchEmployeesWithFirstName(FirstName).ToObservableCollection();
        }


        private bool CanExportEmployeeList(object obj)
        {
            return Employees != null && Employees.Count > 0;
        }
        private void ExportEmployeeList(object obj)
        {
            var filePath = employeeInfoService.ExportDetails(Employees, "Search");
            dialogService.ShowPopUp(Helpers.GetExportStatistics(filePath));
        }

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set
            {
                employees = value;
                OnPropertyChanged();
            }
        }


    }
}

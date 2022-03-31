using EmployeeManager.Messages;
using EmployeeManager.Models;
using EmployeeManager.Services;
using EmployeeManager.Utility;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace EmployeeManager.ViewModels
{
    public class EmployeeOverviewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private readonly IEmployeeInfoService employeeInfoService;
        private readonly IDialogService dialogService;
        public EmployeeOverviewViewModel(IEmployeeInfoService employeeInfoService, IDialogService dialogService)

        {
            this.employeeInfoService = employeeInfoService;
            this.dialogService = dialogService;
            WeakReferenceMessenger.Default.Register<UpdateEmployeeListMessage>(this, OnUpdateEmployeeListMessageReceived);

            LoadEmployeeData();
            InitializeCommands();
        }

        public ICommand EditCommand { get; set; }
        public ICommand ExportCommand { get; set; }
        public ICommand RelaySearchCommand { get; set; }

        private void InitializeCommands()
        {
            EditCommand = new CustomCommand(EditEmployee, CanEditEmployee);
            ExportCommand = new CustomCommand(ExportEmployeeList, CanExportEmployeeList);
            RelaySearchCommand = new CustomCommand(RelaySearch, CanRelaySearch);
        }

        private bool CanRelaySearch(object obj)
        {
            return true;
        }
        private void RelaySearch(object obj)
        {
            dialogService.ShowSearchWindow();
        }

        private bool CanExportEmployeeList(object obj)
        {
            return Employees != null && Employees.Count > 0;
        }
        private void ExportEmployeeList(object obj)
        {
            var filePath = employeeInfoService.ExportDetails(Employees, "Overview");
            dialogService.ShowPopUp(Helpers.GetExportStatistics(filePath));
        }

        
        private bool CanEditEmployee(object obj)
        {
            return SelectedEmployee != null;
        }
        private void EditEmployee(object obj)
        {
            WeakReferenceMessenger.Default.Send(new UpdateEmployeeListMessage(new List<Employee> { SelectedEmployee }));
        }

        private string GetUpdateStatistics(UpdateEmployeeListMessage message)
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($" Updated : {message.Updated.Count}");
            foreach (Employee employee in message.Updated)
            {
                buffer.AppendLine($"    {employee.Name}");
            }

            return buffer.ToString();
        }

        private void OnUpdateEmployeeListMessageReceived(object recipient, UpdateEmployeeListMessage message)
        {
            LoadEmployeeData();
            dialogService.CloseDialog();
            dialogService.ShowPopUp(GetUpdateStatistics(message));
        }

        private void LoadEmployeeData()
        {
            Employees = employeeInfoService.GetAllEmployees().ToObservableCollection();
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
    }
}

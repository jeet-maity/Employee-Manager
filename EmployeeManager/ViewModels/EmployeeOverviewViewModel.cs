using Messages;
using Models;
using ApplicationServices;
using EmployeeManager.ViewServices;
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
using Ninject;

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
            WeakReferenceMessenger.Default.Register<IUpdateEmployeeListMessage>(this, OnUpdateEmployeeListMessageReceived);

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
            var updatedEmployeesMessage = App.Ioc.Get<IUpdateEmployeeListMessage>();
            updatedEmployeesMessage.UpdatedEmployees.Add(SelectedEmployee);
            WeakReferenceMessenger.Default.Send(updatedEmployeesMessage);
        }

        private string GetUpdateStatistics(IUpdateEmployeeListMessage message)
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($" Updated : {message.UpdatedEmployees.Count}");
            foreach (Employee employee in message.UpdatedEmployees)
            {
                buffer.AppendLine($"    {employee.Name}");
            }

            return buffer.ToString();
        }

        private void OnUpdateEmployeeListMessageReceived(object recipient, IUpdateEmployeeListMessage message)
        {
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

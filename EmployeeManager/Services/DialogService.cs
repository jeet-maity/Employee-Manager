using EmployeeManager.Views;
using Ninject;
using System.Windows;

namespace EmployeeManager.Services
{
    public class DialogService : IDialogService
    {
        private Window view;
        public void CloseDialog()
        {
            view?.Close();
        }

        public void ShowPopUp(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowSearchWindow()
        {
            view = App.Ioc.Get<SearchResultsView>();
            view.ShowDialog();
        }
    }
}

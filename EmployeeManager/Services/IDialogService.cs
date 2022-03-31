namespace EmployeeManager.Services
{
    public interface IDialogService
    {
        void ShowSearchWindow();
        void ShowPopUp(string message);
        void CloseDialog();
    }
}

namespace EmployeeManager.ViewServices
{
    public interface IDialogService
    {
        void ShowSearchWindow();
        void ShowPopUp(string message);
        void CloseDialog();
    }
}

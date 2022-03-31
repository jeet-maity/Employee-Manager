using EmployeeManager.ViewModels;
using Ninject;

namespace EmployeeManager
{
    public class ViewModelLocator
    {
        public EmployeeOverviewViewModel LiveEmployeeOverviewViewModel => App.Ioc.Get<EmployeeOverviewViewModel>();

        public SearchResultsViewModel LiveSearchResultsViewModel => App.Ioc.Get<SearchResultsViewModel>();
    }
}

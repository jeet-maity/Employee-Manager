using EmployeeManager.ViewModels;
using Ninject.Modules;

namespace EmployeeManager.Utility
{
    class ViewModelsModule : NinjectModule
    {
        public override void Load()
        {
            RegisterViewModels();
        }

        private void RegisterViewModels()
        {
            Bind<EmployeeOverviewViewModel>().ToSelf().InSingletonScope();
            Bind<SearchResultsViewModel>().ToSelf().InSingletonScope();
        }
    }
}

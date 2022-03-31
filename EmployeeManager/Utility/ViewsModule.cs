using EmployeeManager.Views;
using Ninject.Modules;

namespace EmployeeManager.Utility
{
    class ViewsModule : NinjectModule
    {
        public override void Load()
        {
            RegisterViews();
        }

        private void RegisterViews()
        {
            Bind<EmployeeOverviewView>().ToSelf().InTransientScope();
            Bind<SearchResultsView>().ToSelf().InTransientScope();
        }
    }
}

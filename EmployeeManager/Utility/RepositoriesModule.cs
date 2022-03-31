using EmployeeManager.DAL;
using Ninject.Modules;

namespace EmployeeManager.Utility
{
    class RepositoriesModule : NinjectModule
    {
        public override void Load()
        {
            RegisterRepositories();
        }

        private void RegisterRepositories()
        {
            Bind<IEmployeeRepository>().To<EmployeeRepository>();
        }
    }
}

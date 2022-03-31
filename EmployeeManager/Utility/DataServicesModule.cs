using DataClient;
using Ninject.Modules;

namespace EmployeeManager.Utility
{
    class DataServicesModule : NinjectModule
    {
        public override void Load()
        {
            RegisterDataServices();
        }

        private void RegisterDataServices()
        {
            Bind<IUsersDataClient>().To<UsersDataClient>();
        }
    }
}

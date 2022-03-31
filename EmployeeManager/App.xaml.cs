using EmployeeManager.Utility;
using Ninject;
using Ninject.Modules;
using System.Windows;

namespace EmployeeManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IKernel Ioc;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureIocContainer();
        }

        private void ConfigureIocContainer()
        {
            var modules = new INinjectModule[]
                {
                    new DataServicesModule(),
                    new RepositoriesModule(),
                    new ApplicationServicesModule(),
                    new InfrastructureServicesModule(),
                    new ViewModelsModule(),
                    new ViewsModule()
                };
            Ioc = new StandardKernel(modules);
        }
    }
}

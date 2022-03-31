using EmployeeManager.Infra;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Utility
{
    public class InfrastructureServicesModule : NinjectModule
    {
        public override void Load()
        {
            RegisterInfrastructureServices();
        }

        private void RegisterInfrastructureServices()
        {
            Bind<IFileSystemService>().To<FileSystemService>();
        }
    }
}

﻿using EmployeeManager.ViewServices;
using ApplicationServices;
using Ninject.Modules;

namespace EmployeeManager.Utility
{
    class ApplicationServicesModule : NinjectModule
    {
        public override void Load()
        {
            RegisterApplicationServices();
        }

        private void RegisterApplicationServices()
        {
            Bind<IEmployeeInfoService>().To<EmployeeInfoService>();
            Bind<IDialogService>().To<DialogService>();
            Bind<ViewModelLocator>().ToSelf().InSingletonScope();
        }
    }
}

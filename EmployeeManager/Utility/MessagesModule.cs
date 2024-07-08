using Messages;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Utility
{
    internal class MessagesModule : NinjectModule
    {
        public override void Load()
        {
            RegisterMessages();
        }

        private void RegisterMessages()
        {
            Bind<IUpdateEmployeeListMessage>().To<UpdateEmployeeListMessage>();
        }
    }
}

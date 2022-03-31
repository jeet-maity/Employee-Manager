using System.Collections.Generic;
using EmployeeManager.Models;

namespace EmployeeManager.Messages
{
    class UpdateEmployeeListMessage
    {
        public UpdateEmployeeListMessage(IList<Employee> updated)
        {
            Updated = updated;
        }

        public IList<Employee> Updated { get; set; }
    }
}

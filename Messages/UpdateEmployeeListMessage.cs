using System.Collections.Generic;
using Models;

namespace Messages
{
    public class UpdateEmployeeListMessage : IUpdateEmployeeListMessage
    {
        public UpdateEmployeeListMessage(IList<Employee> updated)
        {
            UpdatedEmployees = updated;
        }

        public IList<Employee> UpdatedEmployees { get; set; }
    }
}

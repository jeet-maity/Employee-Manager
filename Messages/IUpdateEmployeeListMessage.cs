using Models;
using System.Collections.Generic;

namespace Messages
{
    public interface IUpdateEmployeeListMessage
    {
        IList<Employee> UpdatedEmployees { get; set; }
    }
}
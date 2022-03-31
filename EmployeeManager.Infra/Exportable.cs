using System.Threading;
using FileHelpers;

namespace EmployeeManager.Infra
{
    [DelimitedRecord("|")]
    [IgnoreEmptyLines]
    [IgnoreFirst]
    public class Exportable
    {
    }
}
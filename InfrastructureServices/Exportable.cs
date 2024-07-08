using System.Threading;
using FileHelpers;

namespace InfrastructureServices
{
    [DelimitedRecord("|")]
    [IgnoreEmptyLines]
    [IgnoreFirst]
    public class Exportable
    {
    }
}
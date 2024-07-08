using FileHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureServices
{
    public interface IFileSystemService
    {
        string Save<T>(IEnumerable<T> items, string listName) where T : Exportable;
    }
}

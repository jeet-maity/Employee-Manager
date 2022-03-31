using FileHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infra
{
    public class FileSystemService : IFileSystemService
    {
        public string Save<T>(IEnumerable<T> items, string listName) where T : Exportable
        {
            if (items == null || !items.Any())
                return string.Empty;
            try
            {
                var engine = new DelimitedFileEngine<T>(Encoding.UTF8);
                var savedFilePath = Path.Combine(AppContext.BaseDirectory, $@"Exported-{listName}-{typeof(T).Name}-List.csv");
                engine.WriteFile(savedFilePath, items);
                return savedFilePath;
            }
            catch (BadUsageException)
            {
                return string.Empty;
            }
        }
    }
}

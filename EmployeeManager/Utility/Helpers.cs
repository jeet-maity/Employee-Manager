using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Utility
{
    internal class Helpers
    {
        internal static string GetExportStatistics(string filePath)
        {
            StringBuilder buff = new StringBuilder();
            buff.AppendLine("Exported filename: ");
            buff.AppendLine($"      {Path.GetFileName(filePath)}");
            buff.AppendLine();
            buff.AppendLine("Exported to directory: ");
            buff.AppendLine($"      {Path.GetDirectoryName(filePath)}");
            buff.AppendLine();
            buff.AppendLine("Contents: ");
            buff.AppendLine();
            buff.AppendLine(File.ReadAllText(filePath));

            return buff.ToString();
        }
    }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EmployeeManager.Utility
{
    public static class IEnumerableExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }
    }
}

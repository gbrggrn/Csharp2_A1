using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control.Interfaces
{
    internal interface IObservableCollectionManager<T>
    {
        //Methods
        bool Add(T type);
        bool ChangeAt(T type, int indexIn);
        bool CheckIndex(int indexIn);
        void DeleteAll();
        bool DeleteAt(T typeIn);
        T GetAt(int indexIn);

        //Properties
        int Count { get; }
        ObservableCollection<T> Collection { get; }
    }
}

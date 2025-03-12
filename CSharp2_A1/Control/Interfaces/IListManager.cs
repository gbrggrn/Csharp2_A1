using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control.Interfaces
{
    internal interface IListManager<T>
    {
        //Methods
        bool Add(T type);
        bool ChangeAt(T type, int indexIn);
        bool CheckIndex(int indexIn);
        void DeleteAll();
        bool DeleteAt(T typeIn);
        T GetAt(int indexIn);
        string[] ToStringArray();
        List<string> ToStringList();

        //Properties
        int Count { get; }
    }
}

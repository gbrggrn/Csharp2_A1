using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp2_A1.Control.Interfaces;

namespace Csharp2_A1.Control
{
    internal class ListManager<T> : IListManager
    {
        private List<T> list;

        public ListManager()
        {
            list = new();
        }

        internal bool Add(T type)
        {
            if (type != null)
            {
                list.Add(type);
                return true;
            }

            return false;
        }

        internal bool ChangeAt(T type, int indexIn)
        {
            if (CheckIndex(indexIn))
            {
                list[indexIn] = type;
                return true;
            }

            return false;
        }

        private bool CheckIndex(int indexIn)
        {
            if (list != null && indexIn < list.Count)
            {
                list.RemoveAt(indexIn);
                return true;
            }

            return false;
        }

        internal void DeleteAll()
        {
            list.Clear();
        }

        internal bool DeleteAt(int indexIn)
        {
            if (CheckIndex(indexIn))
            {
                list.RemoveAt(indexIn);
                return true;
            }

            return false;
        }

        internal T GetAt(int indexIn)
        {
            if (CheckIndex(indexIn))
            {
                return list[indexIn];
            }
            else
            {
                throw new ArgumentException("Index out of bounds");
            }
        }

        internal string[] ToStringArray()
        {
            string[] listArray = new string[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                {
                    listArray[i] = list[i]!.ToString()!;
                }
            }

            return listArray;
        }

        internal List<string> ToStringList()
        {
            List<string> listStrings = new List<string>();
            foreach (var item in list)
            {
                if (item != null)
                {
                    listStrings.Add(item.ToString()!);
                }
            }

            return listStrings;
        }
    }
}

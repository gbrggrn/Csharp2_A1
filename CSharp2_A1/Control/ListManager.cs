using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Csharp2_A1.Control.Interfaces;

namespace Csharp2_A1.Control
{
    internal class ListManager<T> : IListManager<T>
    {
        private List<T> list;
        private int count;

        public ListManager()
        {
            list = new();
            count = 0;
        }

        public bool Add(T type)
        {
            if (type != null)
            {
                list.Add(type);
                return true;
            }

            return false;
        }

        public bool ChangeAt(T type, int indexIn)
        {
            if (CheckIndex(indexIn))
            {
                list[indexIn] = type;
                return true;
            }

            return false;
        }

        public bool CheckIndex(int indexIn)
        {
            if (list != null && indexIn < list.Count)
            {
                list.RemoveAt(indexIn);
                return true;
            }

            return false;
        }

        public void DeleteAll()
        {
            list.Clear();
            count = 0;
        }

        public bool DeleteAt(int indexIn)
        {
            if (CheckIndex(indexIn))
            {
                list.RemoveAt(indexIn);
                return true;
            }

            return false;
        }

        public T GetAt(int indexIn)
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

        public string[] ToStringArray()
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

        public List<string> ToStringList()
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

        public int Count { get => list.Count; }
    }
}

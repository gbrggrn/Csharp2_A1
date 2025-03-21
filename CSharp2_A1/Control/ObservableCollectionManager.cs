using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Csharp2_A1.Control.Interfaces;

namespace Csharp2_A1.Control
{
    internal class ObservableCollectionManager<T> : IObservableCollectionManager<T>
    {
        private readonly ObservableCollection<T> collection;
        private int count;

        public ObservableCollectionManager()
        {
            collection = [];
            count = 0;
        }

        public bool Add(T typeIn)
        {
            if (typeIn != null)
            {
                collection.Add(typeIn);
                return true;
            }

            return false;
        }

        public bool ChangeAt(T typeIn, int indexIn)
        {
            if (CheckIndex(indexIn))
            {
                collection[indexIn] = typeIn;
                return true;
            }

            return false;
        }

        public bool CheckIndex(int indexIn)
        {
            if (collection != null && indexIn < Count)
            {
                return true;
            }

            return false;
        }

        public void DeleteAll()
        {
            collection.Clear();
            count = 0;
        }

        public bool DeleteAt(T typeIn)
        {
            if (!collection.Contains(typeIn))
            {
                return false;
            }

            collection.Remove(typeIn);
            return true;
        }

        public T GetAt(int indexIn)
        {
            if (CheckIndex(indexIn))
            {
                return collection[indexIn];
            }
            else
            {
                throw new ArgumentException("Index out of bounds");
            }
        }

        public string[] ToStringArray()
        {
            string[] listArray = new string[Count];

            for (int i = 0; i < Count; i++)
            {
                if (collection[i] != null)
                {
                    listArray[i] = collection[i]!.ToString()!;
                }
            }

            return listArray;
        }

        public List<string> ToStringList()
        {
            List<string> listStrings = [];
            foreach (var item in collection)
            {
                if (item != null)
                {
                    listStrings.Add(item.ToString()!);
                }
            }

            return listStrings;
        }

        public int Count { get => collection.Count; }
        public ObservableCollection<T> Collection { get { return collection; } }
    }
}

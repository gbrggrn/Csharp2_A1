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
    public class ObservableCollectionManager<T> : IObservableCollectionManager<T>
    {
        private ObservableCollection<T> collection;

        /// <summary>
        /// Constructor initializes the collection.
        /// </summary>
        public ObservableCollectionManager()
        {
            collection = [];
        }

        /// <summary>
        /// Adds an instance of the type specified to the collection.
        /// </summary>
        /// <param name="typeIn">The instance to be added</param>
        /// <returns>True if successful : false if not</returns>
        public bool Add(T typeIn)
        {
            if (typeIn != null)
            {
                collection.Add(typeIn);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Replaces the entire collection.
        /// </summary>
        /// <param name="collectionIn">The new collection</param>
        /// <returns>True if succesful : false if not</returns>
        public bool Replace(ObservableCollection<T> collectionIn)
        {
            if (collectionIn != null)
            {
                DeleteAll();
                collection = collectionIn;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Replaces a specified element in the collection.
        /// </summary>
        /// <param name="typeIn">The instance that is to be saved</param>
        /// <param name="indexIn">The index of the element to replace</param>
        /// <returns>True if successful : false if not</returns>
        public bool ChangeAt(T typeIn, int indexIn)
        {
            if (CheckIndex(indexIn))
            {
                collection[indexIn] = typeIn;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if an index is in range.
        /// </summary>
        /// <param name="indexIn">The index to be checked</param>
        /// <returns>true if index is in range : false if not</returns>
        public bool CheckIndex(int indexIn)
        {
            if (collection != null && indexIn < Count)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        public void DeleteAll()
        {
            collection.Clear();
        }

        /// <summary>
        /// Deletes a specified element in the collection.
        /// </summary>
        /// <param name="typeIn">The instance to be deleted</param>
        /// <returns>False if element does not exist : true if successful deletion</returns>
        public bool DeleteAt(T typeIn)
        {
            if (!collection.Contains(typeIn))
            {
                return false;
            }

            collection.Remove(typeIn);
            return true;
        }

        /// <summary>
        /// Returns a specific element of the collection based on a given index.
        /// </summary>
        /// <param name="indexIn">Index of the element to be retrieved</param>
        /// <returns>The element corresponding to the given index</returns>
        /// <exception cref="ArgumentException">Throws if index is out of bounds</exception>
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

        //Properties
        public int Count { get => collection.Count; }
        public ObservableCollection<T> Collection { get { return collection; } }
    }
}

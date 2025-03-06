using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp2_A1.Models;
using Csharp2_A1.Models.Enums;

namespace Csharp2_A1.Control
{
    /// <summary>
    /// Comparer logic for sorting methods.
    /// </summary>
    internal class AnimalSorting : IComparer<Animal>
    {
        private readonly Enums.SortBy sortBy;

        /// <summary>
        /// Constructor initializes instance variable.
        /// </summary>
        /// <param name="sortByIn">The chosen enum SortBy</param>
        public AnimalSorting(Enums.SortBy sortByIn)
        {
            sortBy = sortByIn;
        }

        /// <summary>
        /// Defines the comparer logic for sorting animals either by Name or Species.
        /// </summary>
        /// <param name="x">The first animal</param>
        /// <param name="y">The second animal</param>
        /// <returns>
        /// Negative value if "x" comes before "y"
        /// Positive value if "x" comes after "y"
        /// Zero (0) if the params are equal (default case)
        /// </returns>
        /// <exception cref="ArgumentException">Throws if either param is null</exception>
        public int Compare(Animal? x, Animal? y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentException("Can not sort null values");
            }

            return sortBy switch
            {
                Enums.SortBy.Name => string.Compare(x.Name, y.Name, StringComparison.Ordinal),
                Enums.SortBy.Species => string.Compare(x.GetType().Name, y.GetType().Name, StringComparison.Ordinal),
                _ => 0,
            };
        }
    }
}

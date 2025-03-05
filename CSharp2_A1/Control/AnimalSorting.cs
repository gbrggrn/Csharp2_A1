using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp2_A1.Models;
using Csharp2_A1.Models.Enums;

namespace Csharp2_A1.Control
{
    internal class AnimalSorting : IComparer<Animal>
    {
        private readonly Enums.SortBy sortBy;

        public AnimalSorting(Enums.SortBy sortByIn)
        {
            sortBy = sortByIn;
        }

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

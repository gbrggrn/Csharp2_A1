using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Csharp2_A1;

namespace Csharp2_A1
{
    /// <summary>
    /// Helper-class that provides methods for retrieving category and species names from the assembly.
    /// </summary>
    internal static class AssemblyHelpers
    {
        private static readonly Dictionary<string, List<String>> categoriesAndSpecies = GetCategoriesAndSpecies();

        /// <summary>
        /// Retrieves all types in the assembly, then iterates over them to filter out classnames of categories and species.
        /// Adds the categories as keys and the corresponding species as a list as values to a dictionary.
        /// It seems to me this method might be inefficient at scale since it is iterating multiple times over the
        /// entire assembly. I still think this is a fun approach to dynamically retrieve the class-names but
        /// a future small side-project should be to make this more efficient...
        /// </summary>
        /// <returns>The complete dictionary of categories and corresponding species</returns>
        private static Dictionary<string, List<string>> GetCategoriesAndSpecies()
        {
            Dictionary<string, List<string>> categoriesAndSpecies = [];
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            //Iterates over all types to retrieve a category and find its' corresponding species
            foreach (Type category in allTypes)
            {
                if (category.IsClass && category.Namespace == "Csharp2_A1.Models.AnimalCategories")
                {
                    //Initialize list to store species for retrieved category
                    List<string> speciesList = [];

                    //Iterates over all types to retrieve the species connected to the retrieved category
                    foreach (Type species in allTypes)
                    {
                        if (species.IsClass && species.Namespace == $"Csharp2_A1.Models.AnimalSpecies.Species{category.Name}")
                        {
                            //Add retreieved specie to the list of this category
                            speciesList.Add(species.Name);
                        }
                    }
                    //Add the category and its' species to the dictionary
                    categoriesAndSpecies.Add(category.Name, speciesList);
                }
            }
            return categoriesAndSpecies;
        }

        /// <summary>
        /// Returns the name of the category corresponding to the chosen species.
        /// </summary>
        /// <param name="species">The chosen species</param>
        /// <returns>The corresponding category</returns>
        public static string GetCorrespondingCategory(string species)
        {
            foreach (var category in categoriesAndSpecies)
            {
                if (category.Value.Contains(species))
                {
                    return category.Key;
                }
            }
            return string.Empty;
        }

        public static Dictionary<string, List<string>> CategoriesAndSpecies { get => categoriesAndSpecies; }
    }
}

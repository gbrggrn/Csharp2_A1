using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Csharp2_A1.Models
{
    [Serializable]
    public class Ingredient
    {
        string ingredientContent;

        public Ingredient (string ingredientContentIn)
        {
            ingredientContent = ingredientContentIn;
        }

        public Ingredient() 
        {
            ingredientContent = string.Empty;
        }

        public string IngredientContent
        {
            get => ingredientContent;
            set => ingredientContent = value;
        }
    }
}

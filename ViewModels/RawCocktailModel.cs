using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClientConsoleApp
{
    public class RawCocktailSimpleModel
    {
        public int StrDrink { get; set; }
    }
    public class RawCocktailIdsListModel
    {
        public List<RawCocktailIdsListModel> Drinks { get; set; }
    }
    public class RawCocktailFullModel
    {
        public string StrDrink { get; set; }
        public string StrTags { get; set; }
        public string StrCategory { get; set; }
        public string StrAlcoholic { get; set; }
        public string StrGlass { get; set; }
        public string StrInstructions { get; set; }
        public string StrDrinkThumb { get; set; }
        public string StrIngredient1 { get; set; }
        public string StrIngredient2 { get; set; }
        public string StrIngredient3 { get; set; }
        public string StrIngredient4 { get; set; }
        public string StrIngredient5 { get; set; }
        public string StrIngredient6 { get; set; }
        public string StrIngredient7 { get; set; }
        public string StrIngredient8 { get; set; }
        public string StrIngredient9 { get; set; }
        public string StrIngredient10 { get; set; }
        public string StrIngredient11 { get; set; }
        public string StrIngredient12 { get; set; }
        public string StrIngredient13 { get; set; }
        public string StrIngredient14 { get; set; }
        public string StrIngredient15 { get; set; }
    }
}

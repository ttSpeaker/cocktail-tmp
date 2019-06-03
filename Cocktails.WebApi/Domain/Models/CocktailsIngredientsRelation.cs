using Cocktails.WebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cocktails.WebApi.Persistence.Contexts
{
    public class CocktailIngredient
    {
        public int CocktailId { get; set; }
        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
        public Cocktail Cocktail { get; set; }
    }
}

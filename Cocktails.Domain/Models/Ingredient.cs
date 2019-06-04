using Cocktails.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cocktails.Domain.Models
{
    public class Ingredient
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public IList<CocktailIngredient> CocktailWith { get; set; }
    }
}

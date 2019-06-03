using Cocktails.WebApi.Persistence.Contexts;
using Cocktails.WebApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cocktails.WebApi.Domain.Models
{
    public class Cocktail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Thumb { get; set; }
        public string Instructions { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        public IList<CocktailIngredient> IngredientsTo { get; set; }
       
    }
}

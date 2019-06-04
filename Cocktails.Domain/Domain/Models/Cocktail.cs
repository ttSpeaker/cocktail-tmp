using Cocktails.Persistence.Contexts;
using Cocktails.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cocktails.Domain.Models
{
    public class Cocktail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Thumb { get; set; }
        public string Instructions { get; set; }
        public string Alcoholic { get; set; }
        public string Tags { get; set; }
        public string Glass { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        public IList<CocktailIngredient> IngredientsTo { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cocktails.WebApi.Resources
{
    public class CocktailResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Thumb { get; set; }
        public string Instructions { get; set; }
        public string Alcoholic { get; set; }
        public string Tags { get; set; }
        public string Glass { get; set; }

        public CategoryResource Category { get; set; }

        public List<IngredientResource> Ingredients { get; set; }
    }
}

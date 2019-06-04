using Cocktails.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Cocktails.WebApi.Resources
{
    public class SaveCocktailResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Thumb { get; set; }

        [Required]
        public string Instructions { get; set; }

        [Required]
        public int CategoryId { get; set; }

        
        public string Alcoholic { get; set; }

        
        public string Tags { get; set; }

        
        public string Glass { get; set; }

        
        public List<Ingredient> Ingredients { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Cocktails.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Cocktail> Cocktails { get; set; } = new List<Cocktail>();
    }
}

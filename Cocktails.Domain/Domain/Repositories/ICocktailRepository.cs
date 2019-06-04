using Cocktails.Domain.Models;
using Cocktails.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cocktails.Domain.Repositories
{
    public interface ICocktailRepository
    {
        Task<IEnumerable<Cocktail>> ListAsync();
        Task<IEnumerable<Cocktail>> IdAsync(int id);
        Task<Cocktail> FindIdAsync(int id);
        Task AddAsync(Cocktail cocktail, List<Ingredient> ingredients);
        void Update(Cocktail cocktail);
        void Delete(Cocktail cocktail);
        //Task AddRelations(int id, List<Ingredient> ing);
    }
}

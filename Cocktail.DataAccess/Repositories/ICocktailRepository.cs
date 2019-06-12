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
        Task<IEnumerable<Models.Cocktail>> ListAsync();
        Task<IEnumerable<Models.Cocktail>> IdAsync(int id);
        Task<Models.Cocktail> FindIdAsync(int id);
        Task AddAsync(Models.Cocktail cocktail, List<Ingredient> ingredients);
        void Update(Models.Cocktail cocktail);
        void Delete(Models.Cocktail cocktail);
        Task<IEnumerable<Domain.Models.Cocktail>> ListByCategoryAsync(int catId);
        //Task AddRelations(int id, List<Ingredient> ing);
    }
}

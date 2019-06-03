using Cocktails.WebApi.Domain.Models;
using Cocktails.WebApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cocktails.WebApi.Domain.Repositories
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

using Cocktails.WebApi.Domain.Models;
using Cocktails.WebApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cocktails.WebApi.Domain.Services
{
    public interface ICocktailService
    {
        Task<IEnumerable<Cocktail>> ListAsync();
        Task<IEnumerable<Cocktail>> IdAsync(int id);
        Task<CocktailResponse> AddAsync(Cocktail cocktail, List<Ingredient> ingredients);
        Task<CocktailResponse> UpdateAsync(int id, Cocktail cocktail);
        Task<CocktailResponse> DeleteAsync(int id);
        //Task AddRelations(int id, List<Ingredient> ing);
    }
}

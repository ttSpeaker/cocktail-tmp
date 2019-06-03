using Cocktails.WebApi.Domain.Models;
using Cocktails.WebApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cocktails.WebApi.Domain.Services
{
    public interface IIngredientService
    {
        Task<IEnumerable<Ingredient>> ListAsync();
        Task<IngredientResponse> SaveAsync(Ingredient ingredient);
        Task<IngredientResponse> UpdateAsync(int id, Ingredient ingredient);
        Task<IngredientResponse> DeleteAsync(int id);
    }
}

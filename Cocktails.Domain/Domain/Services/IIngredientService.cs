using Cocktails.Domain.Models;
using Cocktails.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cocktails.Domain.Services
{
    public interface IIngredientService
    {
        Task<IEnumerable<Ingredient>> ListAsync();
        Task<IngredientResponse> SaveAsync(Ingredient ingredient);
        Task<IngredientResponse> UpdateAsync(int id, Ingredient ingredient);
        Task<IngredientResponse> DeleteAsync(int id);
    }
}

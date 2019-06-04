using Cocktails.Domain.Models;
using Cocktails.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Cocktails.Domain.Repositories
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> ListAsync();
        Task AddAsync(Ingredient category);
        Task<Ingredient> FindByIdAsync(int id);
        void Update(Ingredient ingredient);
        void Remove(Ingredient ingredient);
    }
}

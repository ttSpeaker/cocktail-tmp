using Cocktails.Domain.Models;
using Cocktails.Domain.Repositories;
using Cocktails.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cocktails.Persistence.Repositories
{
    public class IngredientsRepository : BaseRepository, IIngredientRepository
    {
        public IngredientsRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Ingredient>> ListAsync()
        {
            return await _context.Ingredients.Include(p=>p.CocktailWith).ToListAsync();
        }

        public async Task AddAsync(Ingredient ingredient)
        {
            await _context.Ingredients.AddAsync(ingredient);   
        }

        public async Task<Ingredient> FindByIdAsync(int id)
        {
            return await _context.Ingredients.FindAsync(id);
        }

        public void Update(Ingredient ingredient)
        {
            _context.Ingredients.Update(ingredient);
        }

        public void Remove(Ingredient ingredient)
        {
            _context.Ingredients.Remove(ingredient);
        }
    }
}

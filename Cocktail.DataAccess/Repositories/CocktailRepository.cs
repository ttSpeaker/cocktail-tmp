using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cocktails.Domain.Models;
using Cocktails.Domain.Repositories;
using Cocktails.Persistence.Contexts;

namespace Cocktails.Persistence.Repositories
{
    public class CocktailRepository : BaseRepository, ICocktailRepository
    {
        public CocktailRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Domain.Models.Cocktail>> ListAsync()
        {
            var response = await _context.Cocktails.Include(p => p.Category).Include(p => p.IngredientsTo).ThenInclude(p=>p.Ingredient).ToListAsync();
            return response;
            //var response = await _context.Cocktails.FromSql(
            //    "SELECT c.Id, c.Name as Name, c.Thumb, c.Instructions, c.CategoryId, cat.Id as catId, cat.name as catName, i.Id as IngId, i.Name as IngName " +
            //    "FROM dbo.Cocktails c " +
            //    "LEFT JOIN dbo.CocktailIngredient ci ON c.Id=ci.CocktailId " +
            //    "LEFT JOIN dbo.Ingredients i ON ci.IngredientId=i.Id " +
            //    "JOIN Categories cat ON c.CategoryId=cat.Id").ToListAsync();
            //return response;
        }

        public async Task<IEnumerable<Domain.Models.Cocktail>> IdAsync(int id)
        {
            //ver como implementar obtener entidad con ID con EF y no con QUERYS de SQL
            //return await _context.Cocktails.Include(p => p.Category).Single(el => el.Id==id);
            var query = await _context.Cocktails.FromSql("SELECT * from dbo.Cocktails c " +
                    "JOIN dbo.Categories ca ON c.CategoryId = ca.Id "+
                    "JOIN dbo.CocktailIngredient ci ON ci.CocktailId = c.Id "+
                    "JOIN dbo.Ingredients i ON ci.IngredientId = i.Id "+
                    "WHERE c.Id = {0}", id).ToListAsync();
            return query;
        }

        public async Task<Domain.Models.Cocktail> FindIdAsync(int id)
        {
            return await _context.Cocktails.FindAsync(id);
        }

        public async Task AddAsync(Domain.Models.Cocktail cocktail, List<Ingredient> ingredients)
        {
            var result = await _context.Cocktails.AddAsync(cocktail);

            foreach (Ingredient ing in ingredients)
            {
                var ingRelation = new CocktailIngredient
                {
                    CocktailId = result.Entity.Id,
                    IngredientId = ing.Id
                };

                await _context.Set<CocktailIngredient>().AddAsync(ingRelation);
            }
        }

        public void Update(Domain.Models.Cocktail cocktail)
        {
            _context.Cocktails.Update(cocktail);
        }

        public void Delete(Domain.Models.Cocktail cocktail)
        {
            _context.Cocktails.Remove(cocktail);
        }
    }
}

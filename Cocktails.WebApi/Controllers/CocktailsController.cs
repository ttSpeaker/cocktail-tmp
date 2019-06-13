using System.Collections.Generic;
using System.Threading.Tasks;
using Cocktails.WebApi.Resources;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Cocktails.WebApi.Extensions;
using Cocktails.Domain.Services;
using Cocktails.Persistence.Contexts;

namespace Cocktails.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CocktailsController : ControllerBase
    {
        private readonly ICocktailService _cocktailService;
        private readonly IMapper _mapper;
        private readonly IIngredientService _ingredientService;
        

        public CocktailsController(ICocktailService cocktailService, IMapper mapper, IIngredientService ingredientService)
        {
            _cocktailService = cocktailService;
            _mapper = mapper;
            _ingredientService = ingredientService;
        }
        // GET: api/Cocktails
        [HttpGet]
        public async Task<IEnumerable<CocktailResource>> Get()
        {
            var cocktails = await _cocktailService.ListAsync();
            List<CocktailResource> resources = new List<CocktailResource>();
            foreach (Domain.Models.Cocktail cocktail in cocktails)
            {
                CocktailResource resource = new CocktailResource()
                {
                    Id = cocktail.Id,
                    Name = cocktail.Name,
                    Alcoholic = cocktail.Alcoholic,
                    Category = new CategoryResource() { Id = cocktail.Category.Id, Name = cocktail.Category.Name },
                    Glass = cocktail.Glass,
                    Tags = cocktail.Tags,
                    Instructions = cocktail.Instructions,
                    Thumb = cocktail.Thumb,
                    Ingredients = new List<IngredientResource>() { }
                };
                foreach (CocktailIngredient ingredient in cocktail.IngredientsTo)
                {
                    resource.Ingredients.Add(new IngredientResource() { Id = ingredient.Ingredient.Id, Name = ingredient.Ingredient.Name});
                }
                resources.Add(resource);
            };
            //var resources = _mapper.Map<IEnumerable<Domain.Models.Cocktail>, IEnumerable<CocktailResource>>(cocktails);
            return resources;
        }
        // GET: api/Cocktails/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IEnumerable<CocktailResource>> Get(int id)
        {
            var cocktails = await _cocktailService.IdAsync(id);
            List<CocktailResource> resources = new List<CocktailResource>();
            foreach (Domain.Models.Cocktail cocktail in cocktails)
            {
                CocktailResource resource = new CocktailResource()
                {
                    Id = cocktail.Id,
                    Name = cocktail.Name,
                    Alcoholic = cocktail.Alcoholic,
                    Category = new CategoryResource() { Id = cocktail.Category.Id, Name = cocktail.Category.Name },
                    Glass = cocktail.Glass,
                    Tags = cocktail.Tags,
                    Instructions = cocktail.Instructions,
                    Thumb = cocktail.Thumb,
                    Ingredients = new List<IngredientResource>() { }
                };

                foreach (CocktailIngredient ingredient in cocktail.IngredientsTo)
                {
                    resource.Ingredients.Add(new IngredientResource() { Id = ingredient.Ingredient.Id, Name = ingredient.Ingredient.Name });
                }
                resources.Add(resource);
            }
            return resources;
            //var resources = _mapper.Map<IEnumerable<Domain.Models.Cocktail>, IEnumerable<CocktailResource>>(cocktails);
        }
        // GET: api/Cocktails/cateogry/id
        [HttpGet("category/{CatId}", Name = "GetCateg")]
        public async Task<IEnumerable<CocktailResource>> GetCateg(int CatId)
        {
            var cocktails = await _cocktailService.ListByCategoryAsync(CatId);
            List<CocktailResource> resources = new List<CocktailResource>();
            foreach (Domain.Models.Cocktail cocktail in cocktails)
            {
                CocktailResource resource = new CocktailResource()
                {
                    Id = cocktail.Id,
                    Name = cocktail.Name,
                    Alcoholic = cocktail.Alcoholic,
                    Category = new CategoryResource() { Id = cocktail.Category.Id, Name = cocktail.Category.Name },
                    Glass = cocktail.Glass,
                    Tags = cocktail.Tags,
                    Instructions = cocktail.Instructions,
                    Thumb = cocktail.Thumb,
                    Ingredients = new List<IngredientResource>() { }
                };

                foreach (CocktailIngredient ingredient in cocktail.IngredientsTo)
                {
                    resource.Ingredients.Add(new IngredientResource() { Id = ingredient.Ingredient.Id, Name = ingredient.Ingredient.Name });
                }
                resources.Add(resource);
            }
            return resources;
            //var resources = _mapper.Map<IEnumerable<Domain.Models.Cocktail>, IEnumerable<CocktailResource>>(cocktails);
        }

        // GET: api/Cocktails/ingredients/id
        [HttpGet("ingredients/{IngIds}", Name = "GetByIng")]
        public async Task<IEnumerable<CocktailResource>> GetByIng (int IngIds)
        {
            var cocktails = await _cocktailService.ListByIngredientAsync(IngIds);
            List<CocktailResource> resources = new List<CocktailResource>();
            foreach (Domain.Models.Cocktail cocktail in cocktails)
            { 

                CocktailResource resource = new CocktailResource()
                {
                    Id = cocktail.Id,
                    Name = cocktail.Name,
                    Alcoholic = cocktail.Alcoholic,
                    Category = new CategoryResource() { Id = cocktail.Category.Id, Name = cocktail.Category.Name },
                    Glass = cocktail.Glass,
                    Tags = cocktail.Tags,
                    Instructions = cocktail.Instructions,
                    Thumb = cocktail.Thumb,
                    Ingredients = new List<IngredientResource>() { }
                };
                bool containsIngredient = false;
                foreach (CocktailIngredient ingredient in cocktail.IngredientsTo)
                {
                    if(ingredient.IngredientId == IngIds)
                    {
                        containsIngredient = true;
                    }
                    resource.Ingredients.Add(new IngredientResource() { Id = ingredient.Ingredient.Id, Name = ingredient.Ingredient.Name });
                }

                if (containsIngredient)
                {
                    resources.Add(resource);
                }
            }
            return resources;
            //var resources = _mapper.Map<IEnumerable<Domain.Models.Cocktail>, IEnumerable<CocktailResource>>(cocktails);
        }

        // POST: api/Cocktails
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCocktailResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var cocktail = _mapper.Map<SaveCocktailResource, Domain.Models.Cocktail>(resource);
            var result = await _cocktailService.AddAsync(cocktail, resource.Ingredients);
      
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var cocktailResource = _mapper.Map<Domain.Models.Cocktail, CocktailResource>(result.Cocktail);
            return Ok(cocktailResource);
        }
        // PUT: api/Cocktails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCocktailResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var cocktail = _mapper.Map<SaveCocktailResource, Domain.Models.Cocktail > (resource);
            var result = await _cocktailService.UpdateAsync(id, cocktail);

            if (!result.Success)
                return BadRequest(result.Message);

            var cocktailResource = _mapper.Map<Domain.Models.Cocktail, CocktailResource>(result.Cocktail);
            return Ok(cocktailResource);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _cocktailService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var cocktailResource = _mapper.Map<Domain.Models.Cocktail, CocktailResource>(result.Cocktail);
            return Ok(cocktailResource);
        }
    }
}

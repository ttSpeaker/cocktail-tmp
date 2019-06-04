using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cocktails.WebApi.Resources;
using AutoMapper;
using Cocktails.WebApi.Extensions;
using Cocktails.Domain.Services;
using Cocktails.Domain.Models;

namespace Cocktails.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMapper _mapper;

        public IngredientsController(IIngredientService ingredientService, IMapper mapper)
        {
            _ingredientService = ingredientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<IngredientResource>> GetAllAsync()
        {
            var ingredients = await _ingredientService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientResource>>(ingredients);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveIngredientResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var ingredient = _mapper.Map<SaveIngredientResource, Ingredient>(resource);
            var result = await _ingredientService.SaveAsync(ingredient);

            if (!result.Success)
                return BadRequest(result.Message);

            var ingredientResource = _mapper.Map<Ingredient, IngredientResource>(result.Ingredient);
            return Ok(ingredientResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveIngredientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var ingredient = _mapper.Map<SaveIngredientResource, Ingredient>(resource);
            var result = await _ingredientService.UpdateAsync(id, ingredient);

            if (!result.Success)
                return BadRequest(result.Message);

            var ingredientResource = _mapper.Map<Ingredient, IngredientResource>(result.Ingredient);

            return Ok(ingredientResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _ingredientService.DeleteAsync(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(result.Message);
            }
            var ingredientResource = _mapper.Map<Ingredient, IngredientResource>(result.Ingredient);
            return Ok(ingredientResource);
        }

    }
}

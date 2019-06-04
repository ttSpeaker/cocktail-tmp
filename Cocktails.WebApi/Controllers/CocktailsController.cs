using System.Collections.Generic;
using System.Threading.Tasks;
using Cocktails.WebApi.Resources;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Cocktails.WebApi.Extensions;
using Cocktails.Domain.Models;
using Cocktails.Domain.Services;

namespace Cocktails.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CocktailsController : ControllerBase
    {
        private readonly ICocktailService _cocktailService;
        private readonly IMapper _mapper;
        

        public CocktailsController(ICocktailService cocktailService, IMapper mapper)
        {
            _cocktailService = cocktailService;
            _mapper = mapper;
        }
        // GET: api/Cocktails
        [HttpGet]
        public async Task<IEnumerable<CocktailResource>> Get()
        {
            var cocktails = await _cocktailService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Domain.Models.Cocktail>, IEnumerable<CocktailResource>>(cocktails);
            return resources;
        }

        // GET: api/Cocktails/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IEnumerable<CocktailResource>> Get(int id)
        {
            var cocktails = await _cocktailService.IdAsync(id);
            var resources = _mapper.Map<IEnumerable<Domain.Models.Cocktail>, IEnumerable<CocktailResource>>(cocktails);
            return resources;
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

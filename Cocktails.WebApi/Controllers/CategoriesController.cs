﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cocktails.WebApi.Extensions;
using Cocktails.Domain.Services;
using Cocktails.WebApi.Resources;
using Cocktails.Domain.Models;
using AutoMapper;

namespace Cocktails.WebApi.Controllers
{
    [Route ("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController (ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;  
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            //var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var category = new Category() { Name = resource.Name };
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
	        if (!ModelState.IsValid)
		        return BadRequest(ModelState.GetErrorMessages());

	        var category = _mapper.Map<SaveCategoryResource, Category>(resource);
	        var result = await _categoryService.UpdateAsync(id, category);

	        if (!result.Success)
		        return BadRequest(result.Message);

	        var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);

	        return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

    } 
}

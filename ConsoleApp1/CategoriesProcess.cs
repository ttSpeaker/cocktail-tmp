using AutoMapper;
using Cocktails.Domain.Models;
using Cocktails.Domain.Services;
using Cocktails.WebApi.Resources;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class CategoriesProcess : ICategoriesProcess
    {
        private readonly ICategoryService _categoriesService;
        private readonly IMapper _mapper;

        public CategoriesProcess(ICategoryService categoriesService, IMapper mapper)
        {
            _mapper = mapper;
            _categoriesService = categoriesService;
        }

        public async Task<RawCategoriesList> LoadCategories()
        {
            string url = "https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list";
            using (HttpResponseMessage response = await ApiHelper.HttpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    RawCategoriesList RawCategories = await response.Content.ReadAsAsync<RawCategoriesList>();
                    return RawCategories;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public List<SaveCategoryResource> ProcessCategoryData (RawCategoriesList rawCategoriesList)
        {
            List<SaveCategoryResource> categories = new List<SaveCategoryResource>();
            foreach (RawCategoryModel rawCat in rawCategoriesList.Drinks)
            {
                categories.Add(new SaveCategoryResource() { Name = rawCat.StrCategory });
            }
            return categories;
        }
        public async void SaveCategories(List<SaveCategoryResource> resources)
        {
            //SAVE EACH CATEGORY
            foreach (SaveCategoryResource resource in resources)
            {
                var category = _mapper.Map<SaveCategoryResource, Category>(resource);
                await _categoriesService.SaveAsync(category);
            }
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _categoriesService.ListAsync();
        }


    }
}

using AutoMapper;
using Cocktails.Domain.Models;
using Cocktails.Domain.Repositories;
using Cocktails.Domain.Services;
using Cocktails.WebApi.Resources;
using ConsoleApp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiClientConsoleApp
{
    public class IngredientsProcess : IIngredientsProcess
    {
        private readonly IIngredientService _ingridientsService;
        private readonly IMapper _mapper;

        public IngredientsProcess(IIngredientService ingridientsService, IMapper mapper)
        {
            _ingridientsService = ingridientsService;
            _mapper = mapper;
        }

        public async Task<RawIngredientsList> LoadIngredients()
        {
            string url = "https://www.thecocktaildb.com/api/json/v1/1/list.php?i=list";
            using (HttpResponseMessage response = await ApiHelper.HttpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    RawIngredientsList RawIngredients = await response.Content.ReadAsAsync<RawIngredientsList>();
                    return RawIngredients;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public List<SaveIngredientResource> ProcessIngredientData(RawIngredientsList rawIngredientsList)
        {
            List<SaveIngredientResource> ingredients = new List<SaveIngredientResource>();
            foreach (RawIngredientModel rawIng in rawIngredientsList.Drinks)
            {
                ingredients.Add(new SaveIngredientResource() { Name = rawIng.StrIngredient1 });
            }
            return ingredients;
        }
        public async void SaveIngredients(List<SaveIngredientResource> resources)
        {
            //SAVE EACH INGREDIENT
            foreach (SaveIngredientResource resource in resources)
            {
                var ingredient = _mapper.Map<SaveIngredientResource, Ingredient>(resource);
                await _ingridientsService.SaveAsync(ingredient);
            }
        }
        
        public async Task<IEnumerable<Ingredient>> GetAllIngredients()
        {
            return await _ingridientsService.ListAsync();
        }
    }
}

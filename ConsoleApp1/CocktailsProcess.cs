using AutoMapper;
using Cocktails.Domain.Models;
using Cocktails.Domain.Services;
using Cocktails.WebApi.Resources;
using ConsoleApp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiClientConsoleApp
{
    class CocktailsProcess : ICocktailProcess
    {
        private readonly ICocktailService _cocktailsService;
        private readonly IMapper _mapper;

        public CocktailsProcess(ICocktailService cocktailsService, IMapper mapper)
        {
            _mapper = mapper;
            _cocktailsService = cocktailsService;
        }

        public async Task<RawCocktailIdsListModel> LoadCocktailsIds(string url)
        {
            //string url = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Ordinary_Drink";
            using (HttpResponseMessage response = await ApiHelper.HttpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Succesfull response");
                    RawCocktailIdsListModel RawCocktailsIds = await response.Content.ReadAsAsync<RawCocktailIdsListModel>();
                    return RawCocktailsIds;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async Task<RawCocktailFullModel> LoadCocktail(int id)
        {
            string url = "https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i="+id;
            using (HttpResponseMessage response = await ApiHelper.HttpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    RawCocktailFullModel RawCocktailsIds = await response.Content.ReadAsAsync<RawCocktailFullModel>();
                    return RawCocktailsIds;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public SaveCocktailResource ProcessCocktailData (RawCocktailFullModelItem rawCocktail, int catId)
        {
            SaveCocktailResource cocktail = new SaveCocktailResource()
            {
                Name = rawCocktail.StrDrink,
                Alcoholic = rawCocktail.StrAlcoholic,
                CategoryId = catId,
                Glass = rawCocktail.StrGlass,
                Thumb = rawCocktail.StrDrinkThumb,
                Tags = rawCocktail.StrTags,
                Instructions = rawCocktail.StrInstructions
            };
            return cocktail;
        }

        public int GetCategoryId (string categoryName, List<Category> allCategories)
        {
            int category = (allCategories.Find(c => c.Name == categoryName)).Id;
            return category;
        }

        public List<Ingredient> getCocktailIngredients(RawCocktailFullModelItem rawCocktail, List<Ingredient> AllIngredients)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            Ingredient ingredient = new Ingredient();

            if (rawCocktail.StrIngredient1.Length > 1)
            {
                ingredient = AllIngredients.Find(i => i.Name == rawCocktail.StrIngredient1);
                ingredients.Add(ingredient);
            }
            if (rawCocktail.StrIngredient2.Length > 1)
            {
                ingredient = AllIngredients.Find(i => i.Name == rawCocktail.StrIngredient1);
                ingredients.Add(ingredient);
            }
            if (rawCocktail.StrIngredient3.Length > 1)
            {
                ingredient = AllIngredients.Find(i => i.Name == rawCocktail.StrIngredient1);
                ingredients.Add(ingredient);
            }
            if (rawCocktail.StrIngredient4.Length > 1)
            {
                ingredient = AllIngredients.Find(i => i.Name == rawCocktail.StrIngredient1);
                ingredients.Add(ingredient);
            }
            if (rawCocktail.StrIngredient5.Length > 1)
            {
                ingredient = AllIngredients.Find(i => i.Name == rawCocktail.StrIngredient1);
                ingredients.Add(ingredient);
            }
            if (rawCocktail.StrIngredient6.Length > 1)
            {
                ingredient = AllIngredients.Find(i => i.Name == rawCocktail.StrIngredient1);
                ingredients.Add(ingredient);
            }
            if (rawCocktail.StrIngredient7.Length > 1)
            {
                ingredient = AllIngredients.Find(i => i.Name == rawCocktail.StrIngredient1);
                ingredients.Add(ingredient);
            }
            if (rawCocktail.StrIngredient8.Length > 1)
            {
                ingredient = AllIngredients.Find(i => i.Name == rawCocktail.StrIngredient1);
                ingredients.Add(ingredient);
            }
            if (rawCocktail.StrIngredient9.Length > 1)
            {
                ingredient = AllIngredients.Find(i => i.Name == rawCocktail.StrIngredient1);
                ingredients.Add(ingredient);
            }
            if (rawCocktail.StrIngredient10.Length > 1)
            {
                ingredient = AllIngredients.Find(i => i.Name == rawCocktail.StrIngredient1);
                ingredients.Add(ingredient);
            }
            if (rawCocktail.StrIngredient11.Length > 1)
            {
                ingredient = AllIngredients.Find(i => i.Name == rawCocktail.StrIngredient1);
                ingredients.Add(ingredient);
            }
            if (rawCocktail.StrIngredient12.Length > 1)
            {
                ingredient = AllIngredients.Find(i => i.Name == rawCocktail.StrIngredient1);
                ingredients.Add(ingredient);
            }
            if (rawCocktail.StrIngredient13.Length > 1)
            {
                ingredient = AllIngredients.Find(i => i.Name == rawCocktail.StrIngredient1);
                ingredients.Add(ingredient);
            }
            if (rawCocktail.StrIngredient14.Length > 1)
            {
                ingredient = AllIngredients.Find(i => i.Name == rawCocktail.StrIngredient1);
                ingredients.Add(ingredient);
            }
            if (rawCocktail.StrIngredient15.Length > 1)
            {
                ingredient = AllIngredients.Find(i => i.Name == rawCocktail.StrIngredient1);
                ingredients.Add(ingredient);
            }
            return ingredients;
        }

        public async void SaveCocktail (SaveCocktailResource resource, List<Ingredient> ingredients)
        {
            var cocktail = _mapper.Map<SaveCocktailResource, Cocktails.Domain.Models.Cocktail>(resource);
            await _cocktailsService.AddAsync(cocktail, ingredients);
        }
    }
}

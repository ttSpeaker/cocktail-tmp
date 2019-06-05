using Cocktails.Domain.Repositories;
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
        //private readonly IIngredientRepository _ingridientsRepository;

        //public IngredientsProcess(IIngredientRepository ingridientsRepository)
        //{
        //    _ingridientsRepository = ingridientsRepository;
        //}

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
        public void SaveIngredients(List<SaveIngredientResource> ingredients)
        {
            //SAVE EACH INGREDIENT
            foreach (SaveIngredientResource ingredient in ingredients)
            {
                Console.WriteLine(ingredient.Name);
            }
        }
    }
}

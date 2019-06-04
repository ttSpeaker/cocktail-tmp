using Cocktails.WebApi.Resources;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiClientConsoleApp
{
    class IngredientsProcess
    {
        public static async Task<RawIngredientsList> LoadIngredients()
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
        public static List<SaveIngredientResource> ProcessIngredientData(RawIngredientsList rawIngredientsList)
        {
            List<SaveIngredientResource> ingredients = new List<SaveIngredientResource>();
            foreach (RawIngredientModel rawIng in rawIngredientsList.Drinks)
            {
                ingredients.Add(new SaveIngredientResource() { Name = rawIng.StrIngredient1 });
            }
            return ingredients;
        }
        public static void SaveIngredients(List<SaveIngredientResource> ingredients)
        {
            //SAVE EACH INGREDIENT
            foreach (SaveIngredientResource ingredient in ingredients)
            {
                Console.WriteLine(ingredient.Name);
            }
        }
    }
}
